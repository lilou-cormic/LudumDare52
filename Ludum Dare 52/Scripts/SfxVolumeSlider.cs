using Godot;

public class SfxVolumeSlider : HSlider
{
    private AudioStreamPlayer _sfxPlayer;

    public override void _Ready()
    {
        _sfxPlayer = GetChild<AudioStreamPlayer>(0);

        Value = GameManager.SfxVolume;

        _sfxPlayer.VolumeDb = (float)Value;
    }

    private void OnValueChanged(float value)
    {
        GameManager.SfxVolume = value;

        _sfxPlayer.VolumeDb = (float)Value;
        _sfxPlayer.Play();
    }
}