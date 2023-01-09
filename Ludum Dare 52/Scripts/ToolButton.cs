using Godot;

public class ToolButton : Button
{
    [Export] ToolType ToolType = ToolType.None;

    public override void _Ready()
    {
        GameManager.CurrentToolTypeChanged += SetPressed;

        SetPressed();
    }

    public override void _Toggled(bool buttonPressed)
    {
        if (buttonPressed)
            GameManager.CurrentToolType = ToolType;

        SetPressed();
    }

    private void SetPressed()
    {
        SetPressedNoSignal(GameManager.CurrentToolType == ToolType);
    }
}