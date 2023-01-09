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

    public static int Day { get; private set; } = 1;

    public static Season Season { get; private set; } = Season.Spring;

    public static float MusicVolume = 0;

    public static float SfxVolume = 0;

    #endregion

    #region Events

    public static event Action CurrentCropTypeChanged;

    public static event Action MoneyChanged;

    public static event Action DayPassed;

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

    public void OnEndDayPressed()
    {
        Day++;

        if (Day >= 31)
            ChangeSeason();

        DayPassed?.Invoke();
    }

    private void ChangeSeason()
    {
        switch (Season)
        {
            case Season.Spring:
                Season = Season.Summer;
                break;

            case Season.Summer:
                Season = Season.Fall;
                break;

            case Season.Fall:
                Season = Season.Spring;
                break;
        }

        Day = 1;
        DayPassed?.Invoke();
    }

    #endregion
}
