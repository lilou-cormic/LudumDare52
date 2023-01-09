using Godot;

public class SeasonMusicPlayer : Node2D
{
    private AudioStreamPlayer _springMusicPlayer;

    private AudioStreamPlayer _summerMusicPlayer;

    private AudioStreamPlayer _fallMusicPlayer;

    public override void _Ready()
    {
        _springMusicPlayer = GetChild<AudioStreamPlayer>(0);
        _summerMusicPlayer = GetChild<AudioStreamPlayer>(1);
        _fallMusicPlayer = GetChild<AudioStreamPlayer>(2);

        SetVolume();

        GameManager.DayPassed += SetVolume;
    }

    private void SetVolume()
    {
        _springMusicPlayer.VolumeDb = GameManager.Season == Season.Spring ? GameManager.MusicVolume : -80;
        _summerMusicPlayer.VolumeDb = GameManager.Season == Season.Summer ? GameManager.MusicVolume : -80;
        _fallMusicPlayer.VolumeDb = GameManager.Season == Season.Fall ? GameManager.MusicVolume : -80;
    }
}