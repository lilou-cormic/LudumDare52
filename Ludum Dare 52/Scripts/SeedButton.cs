using Godot;

public class SeedButton : Button
{
    [Export] CropType CropType = CropType.None;

    private CropDef _def;

    public override void _Ready()
    {
        _def = Crops.GetCropDef(CropType);

        GameManager.CurrentCropTypeChanged += SetPressed;
        GameManager.DayPassed += SetEnabled;
        GameManager.MoneyChanged += SetEnabled;

        SetPressed();
        SetEnabled();
    }

    public override void _Toggled(bool buttonPressed)
    {
        if (buttonPressed)
            GameManager.CurrentCropType = CropType;

        SetPressed();
    }

    private void SetPressed()
    {
        SetPressedNoSignal(GameManager.CurrentCropType == CropType);
    }

    private void SetEnabled()
    {
        Disabled = !_def.Season.HasFlag(GameManager.Season) || GameManager.Money < _def.SeedCost;
    }
}