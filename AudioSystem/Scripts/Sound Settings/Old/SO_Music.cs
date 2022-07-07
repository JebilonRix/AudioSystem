using UnityEngine;

namespace RedPanda.AudioSystem
{
    [CreateAssetMenu(fileName = "Music", menuName = "Red Panda/Audio/Music")]
    public class SO_Music : SO_BaseAudioSettings
    {
        #region Fields
        [Header("Clips")]
        [SerializeField] private AudioClip _clip;
        [SerializeField] private bool _isLoop = true;

        public AudioClip Clip { get => _clip; }
        #endregion Fields

        #region Public Methods
        public override void PlayAudio(AudioSource source)
        {
            if (Clip == null)
            {
                return;
            }

            if (source.outputAudioMixerGroup == null)
            {
                source.outputAudioMixerGroup = _outputMixerGroup;
            }

            source.loop = _isLoop;
            source.bypassEffects = _byPassEffects;
            source.clip = Clip;
            source.volume = _volume;

            if (_spatialBlend > 0)
            {
                _minDistance = _soundArea;
                _maxDistance = _soundArea * 2.5f;
            }

            source.Play();
        }
        public override void StopAudio(AudioSource source)
        {
            source.Stop();
        }
        #endregion Public Methods
    }
}