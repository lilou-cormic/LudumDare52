using Godot;

public class SeedButton : Button
{
    [Export] CropType CropType = CropType.None;

    public override void _Ready()
    {
        GameManager.CurrentCropTypeChanged += SetPressed;

        SetPressed();
    }

    public override void _Toggled(bool buttonPressed)
    {
        if (buttonPressed)
            GameManager.CurrentCropType = CropType;
    }

    private void SetPressed()
    {
        SetPressedNoSignal(GameManager.CurrentCropType == CropType);
    }
}
