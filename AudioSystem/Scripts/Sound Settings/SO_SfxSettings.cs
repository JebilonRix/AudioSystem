using UnityEngine;

namespace RedPanda.AudioSystem
{
    [CreateAssetMenu(fileName = "SfxSettings", menuName = "Red Panda/Audio/Sfx Settings")]
    public class SO_SfxSettings : SO_Settings
    {
        #region Fields And Properties
        [Header("Pitch Settings")]
        [SerializeField] private bool _isRandomPitch = false;
        [SerializeField] private float _pitch = 1f;
        [SerializeField][Range(0.1f, 3f)] private float _minPitchValue = 0.9f;
        [SerializeField][Range(0.1f, 3f)] private float _maxPitchValue = 1.1f;
        #endregion Fields And Properties

        private void OnEnable()
        {
            if (_minPitchValue > _maxPitchValue)
            {
                _maxPitchValue = _minPitchValue + 1f;
            }
        }

        public override void Settings(AudioSource source)
        {
            if (_isRandomPitch)
            {
                source.pitch = Random.Range(_minPitchValue, _maxPitchValue);
            }
            else
            {
                source.pitch = _pitch;
            }

            base.Settings(source);
        }
    }
}