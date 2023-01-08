using Godot;
using System;

public class GameManager : Node2D
{
    #region Data

    private static CropType _CurrentCropType;
    public static CropType CurrentCropType
    {
        get => _CurrentCropType;

        set
        {
            if (_CurrentCropType != value)
            {
                _CurrentCropType = value;
                CurrentCropTypeChanged?.Invoke();
            }
        }
    }

    public static int Money { get; private set; } = 100;

    #endregion

    #region Events

    public static event Action CurrentCropTypeChanged;

    public static event Action MoneyChanged;

    #endregion

    #region Initialisation

    public override void _Ready()
    {
        CurrentCropType = CropType.Turnip;
    }
    #endregion

    #region Methods

    public static void ChangeMoney(int amount)
    {
        Money += amount;

        if (Money < 0)
            Money = 0;

        MoneyChanged?.Invoke();
    }

    #endregion
}
