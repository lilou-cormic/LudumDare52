using Godot;

public class MusicPlayer : AudioStreamPlayer
{
    public override void _Ready()
    {
        VolumeDb = GameManager.MusicVolume;
    }
}