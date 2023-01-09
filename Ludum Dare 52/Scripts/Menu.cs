using Godot;
using System.Net.NetworkInformation;

public class Menu : Control
{
    public void OnPlayButtonPressed()
    {
        GetTree().ChangeScene(@"res://Scenes/Main.tscn");
    }

    public void OnOptionsButtonPressed()
    {
        GetTree().ChangeScene(@"res://Scenes/Options.tscn");
    }

    public void OnCreditsButtonPressed()
    {
        GetTree().ChangeScene(@"res://Scenes/Credits.tscn");
    }

    public void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }
}
