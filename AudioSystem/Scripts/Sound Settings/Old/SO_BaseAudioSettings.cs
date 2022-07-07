using UnityEngine;
using UnityEngine.Audio;

namespace RedPanda.AudioSystem
{
    public abstract class SO_BaseAudioSettings : ScriptableObject
    {
        #region Fields
        [Header("Fundamental Settings")]
        [SerializeField] protected AudioMixerGroup _outputMixerGroup;
        [Range(0, 1)][SerializeField] protected float _volume = 1f;
        [SerializeField] protected bool _byPassEffects = true;

        [Header("Spatial Settings")]
        [Range(0, 1)][SerializeField] protected float _spatialBlend = 0f;
        [SerializeField] protected float _soundArea = 5f;
        protected float _minDistance;
        protected float _maxDistance;
        #endregion Fields

        #region Public Methods
        public abstract void PlayAudio(AudioSource source);
        public abstract void StopAudio(AudioSource source);
        #endregion Public Methods
    }
}