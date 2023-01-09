using Godot;

public class Credits : Node
{
    public void OnBackButtonPressed()
    {
        GetTree().ChangeScene(@"res://Scenes/Menu.tscn");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ui_accept") || Input.IsActionJustPressed("ui_cancel"))
            OnBackButtonPressed();
    }
}
