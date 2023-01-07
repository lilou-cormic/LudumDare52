using PurpleCable;
using System;

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
            if (_DaysToGrow != value)
            {
                _DaysToGrow = value;
                Age = 0;
            }
        }
    }

    #endregion

    #region Events

    public event Action StateChanged;

    #endregion

    #region Methods

    public void Plant(CropDef cropDef)
    {
        if (cropDef != null)
        {
            Def = cropDef;
            DaysToGrow = cropDef.GrowthDays;
            State = CropState.Growing;
        }
    }

    public void Grow()
    {
        if (State == CropState.Growing || State == CropState.Regrowing || State == CropState.Ready)
        {
            Age++;

            if (Age >= DaysToGrow)
                State = CropState.Ready;
        }
    }

    public void Harvest()
    {
        if (State == CropState.Ready)
        {
            ScoreManager.AddPoints(Def.SellPrice);

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

    #endregion
}
