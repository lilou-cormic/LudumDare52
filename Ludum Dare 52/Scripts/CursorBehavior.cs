using Godot;

public class CursorBehavior : Sprite
{
    public override void _Ready()
    {
        GameManager.CurrentCropTypeChanged += SetCursor;
        GameManager.CurrentToolTypeChanged += SetCursor;

        SetCursor();
    }

    public override void _ExitTree()
    {
        GameManager.CurrentCropTypeChanged -= SetCursor;
        GameManager.CurrentToolTypeChanged -= SetCursor;
    }

    public override void _Process(float delta)
    {
        Position = GetGlobalMousePosition();
    }

    public override void _Notification(int what)
    {
        switch (what)
        {
            case MainLoop.NotificationWmMouseExit:
                Visible = false;
                break;

            case MainLoop.NotificationWmMouseEnter:
                Visible = true;
                break;
        }
    }

    private void SetCursor()
    {
        switch (GameManager.CurrentToolType)
        {
            case ToolType.SeedBag:
                Texture = Crops.GetCropDef(GameManager.CurrentCropType).Cursor;
                break;
            default:
                Texture = Tools.GetToolDef(GameManager.CurrentToolType)?.Cursor;
                break;
        }
    }
}
