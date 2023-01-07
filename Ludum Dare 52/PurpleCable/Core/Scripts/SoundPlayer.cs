using Godot;

namespace PurpleCable
{
    /// <summary>
    /// Sound player [MonoBehaviour] - Requires AudioSource
    /// </summary>
    //[RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : Singleton<SoundPlayer>
    {
        #region Components

        /// <summary>
        /// Audio source
        /// </summary>
        private static AudioStreamPlayer _audioSource;

        #endregion

        #region Properties

        /// <summary>
        /// Volume
        /// </summary>
        public static float Volume
        {
            get => PlayerPrefs.GetFloat("SoundVolume", 0.5f);

            set
            {
                PlayerPrefs.SetFloat("SoundVolume", value);

                //TODO Godot - if (_audioSource != null && _audioSource.outputAudioMixerGroup == null)
                //TODO Godot -     _audioSource.volume = value;
            }
        }

        #endregion

        #region Initialization

        public SoundPlayer()
        { }

        #endregion

        #region Functions

        public static void SetAudioSource(AudioStreamPlayer audioSource)
        {
            _audioSource = audioSource;

            //TODO Godot - if (_audioSource.outputAudioMixerGroup == null)
            {
                // Get saved sfx volume
                _audioSource.VolumeDb = Volume;
            }
        }

        /// <summary>
        /// Plays the audio clip though the audio source
        /// </summary>
        /// <param name="clip">The audio clip (can be null)</param>
        /// <param name="pitch">The change in pitch (can be null or from 1 to 10) [null by default]</param>
        public static void Play(AudioStream clip, int? pitch = null)
        {
            if (clip != null && _audioSource != null)
            {
                if (pitch.HasValue)
                    _audioSource.PitchScale = 1 + (pitch.Value / 10f);
                else
                    _audioSource.PitchScale = 1;

                //TODO Godot - _audioSource.PlayOneShot(clip);
            }
        }

        #endregion
    }
}
