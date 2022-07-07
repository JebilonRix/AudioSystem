using UnityEngine;
using static UnityEngine.Random;

namespace RedPanda.AudioSystem
{
    [CreateAssetMenu(fileName = "Sfx", menuName = "Red Panda/Audio/Sfx")]
    public class SO_Sfx : SO_BaseAudioSettings
    {
        #region Fields
        [Header("Pitch Settings")]
        [Range(0.1f, 3f)][SerializeField] private float _pitch = 1f;
        [SerializeField] private bool _isRandomPitch = false;
        [SerializeField] private float _minPitchValue = 0.9f;
        [SerializeField] private float _maxPitchValue = 1.1f;

        [Header("Clips")]
        [SerializeField] private bool _isRandomClip = false;
        [SerializeField] private AudioClip[] _clips;
        #endregion Fields

        #region Properties
        public AudioClip Clip
        {
            get
            {
                if (_isRandomClip)
                {
                    return _clips[Range(0, _clips.Length)];
                }
                else
                {
                    return _clips[0];
                }
            }
        }
        public float Pitch
        {
            get
            {
                if (_isRandomPitch)
                {
                    if (_minPitchValue > _maxPitchValue)
                    {
                        return Range(_maxPitchValue, _minPitchValue);
                    }
                    else if (_minPitchValue == _maxPitchValue)
                    {
                        _isRandomPitch = false;
                        return _pitch;
                    }
                    else
                    {
                        return Range(_minPitchValue, _maxPitchValue);
                    }
                }
                else
                {
                    return _pitch;
                }
            }
        }
        #endregion Properties

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

            source.bypassEffects = _byPassEffects;
            source.clip = Clip;
            source.volume = _volume;
            source.pitch = Pitch;

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