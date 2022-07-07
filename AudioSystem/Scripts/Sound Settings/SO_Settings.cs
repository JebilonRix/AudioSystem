using UnityEngine;
using UnityEngine.Audio;

namespace RedPanda.AudioSystem
{
    public abstract class SO_Settings : ScriptableObject
    {
        #region Fields And Properties
        [Header("Fundamental Settings")]
        [SerializeField] protected AudioMixerGroup p_mixerGroup;
        [SerializeField][Range(0f, 1f)] protected float p_volume = 1f;
        [SerializeField] protected bool p_byPassEffects = false;
        [SerializeField] protected bool p_byPassReverb = false;
        private bool _isSetted = false;

        [Header("Spatial Settings")]
        [SerializeField] protected bool p_isSpatial = false;
        [SerializeField] private AudioRolloffMode _rolloffMode = AudioRolloffMode.Logarithmic;
        [SerializeField][Range(0f, 1f)] private float _spatialBlend = 0f;
        [SerializeField][Range(1f, 250f)] private float _limitOfHearingDistance = 5f;
        [SerializeField][Range(1f, 500f)] private float _maxLimitOfHearingDistance = 10f;
        [SerializeField][Range(0, 360)] private int _spread = 0;
        [SerializeField][Range(0f, 5f)] private float _dopplerLevel = 1f;
        #endregion Fields And Properties

        #region Unity Methods
        private void OnEnable()
        {
            if (_limitOfHearingDistance >= _maxLimitOfHearingDistance)
            {
                _maxLimitOfHearingDistance = _limitOfHearingDistance * 2;
            }
        }
        private void OnDisable()
        {
            _isSetted = false;
        }
        #endregion Unity Methods

        public virtual void Settings(AudioSource source)
        {
            if (_isSetted)
            {
                return;
            }

            _isSetted = true;

            source.outputAudioMixerGroup = p_mixerGroup;
            source.volume = p_volume;
            source.bypassEffects = p_byPassEffects;
            source.bypassReverbZones = p_byPassReverb;

            if (!p_isSpatial)
            {
                return;
            }

            source.spatialBlend = 1f;
            source.rolloffMode = _rolloffMode;
            source.minDistance = _limitOfHearingDistance;
            source.maxDistance = _maxLimitOfHearingDistance;
            source.spread = _spread;
            source.dopplerLevel = _dopplerLevel;
        }
    }
}