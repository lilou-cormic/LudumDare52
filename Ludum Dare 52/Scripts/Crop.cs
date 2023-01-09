using Godot;
using System;
using System.Linq.Expressions;

public class Crop
{
    #region Data

    public CropDef Def { get; private set; }

    public int Age { get; private set; }

    private CropState _State;
    public CropState State
    {
        get => _State;

        set
        {
            if (_State != value)
            {
                _State = value;

                if (_State == CropState.Empty)
                {
                    Def = null;
                    DaysToGrow = 0;
                }

                StateChanged?.Invoke();
            }
        }
    }

    private int _DaysToGrow;
    public int DaysToGrow
    {
        get => _DaysToGrow;

        set
        {
            _DaysToGrow = value;
            Age = 0;
        }
    }

    public bool CanHarvest => State == CropState.Ready || State == CropState.Dead;

    #endregion

    #region Events

    public event Action StateChanged;

    #endregion

    #region Initialisation

    public Crop()
    {
        GameManager.DayPassed += OnDayPassed;
    }

    #endregion

    #region Methods

    public void Plant(CropDef cropDef)
    {
        if (State == CropState.Empty && cropDef != null)
        {
            if (cropDef.Season.HasFlag(GameManager.Season) && cropDef.SeedCost <= GameManager.Money)
            {
                GameManager.ChangeMoney(-cropDef.SeedCost);

                Def = cropDef;
                DaysToGrow = cropDef.GrowthDays;
                State = CropState.Growing;
            }
        }
    }

    public void Grow()
    {
        if (State == CropState.Growing || State == CropState.Regrowing || State == CropState.Ready)
        {
            Age++;

            if (Age >= DaysToGrow)
                State = CropState.Ready;
            else
                StateChanged?.Invoke();
        }
    }

    public void Harvest()
    {
        if (!CanHarvest)
            return;

        if (State == CropState.Ready)
        {
            GameManager.ChangeMoney(Def.SellPrice);

            if (Def.CanRegrow)
            {
                StartRegrowing();
                return;
            }
        }

        State = CropState.Empty;
    }

    public void StartRegrowing()
    {
        DaysToGrow = Def.RegrowthDays;
        State = CropState.Regrowing;
    }

    public void Die()
    {
        State = CropState.Dead;
    }

    public void OnDayPassed()
    {
        if (State != CropState.Empty)
        {
            if (Def.Season.HasFlag(GameManager.Season))
                Grow();
            else
                Die();
        }
    }

    #endregion
}
