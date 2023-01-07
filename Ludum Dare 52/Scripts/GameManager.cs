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

    #endregion

    #region Events

    public static event Action CurrentCropTypeChanged;

    #endregion
}
