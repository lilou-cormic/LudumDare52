using Godot;

public class MusicVolumeSlider : HSlider
{
    private MusicPlayer _musicPlayer;

    public override void _Ready()
    {
        _musicPlayer = GetChild<MusicPlayer>(0);

        Value = GameManager.MusicVolume;
    }

    private void OnValueChanged(float value)
    {
        GameManager.MusicVolume = value;

        _musicPlayer.VolumeDb = value;
    }
}
