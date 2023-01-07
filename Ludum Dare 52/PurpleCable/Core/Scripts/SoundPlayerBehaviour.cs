using Godot;

namespace PurpleCable
{
    /// <summary>
    /// Sound player [MonoBehaviour] - Requires AudioSource
    /// </summary>
    //[RequireComponent(typeof(AudioSource))]
    public class SoundPlayerBehaviour : Node2D
    {
        #region Components

        ///// <summary>
        ///// Audio source
        ///// </summary>
        //private AudioStreamPlayer _audioSource;

        #endregion

        #region Initialization

        public override void _Ready()
        {
            SoundPlayer.SetAudioSource(GetChild<AudioStreamPlayer>(0));
        }

        #endregion
    }
}
