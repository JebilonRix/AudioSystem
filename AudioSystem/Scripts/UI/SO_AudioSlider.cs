using UnityEngine;
using UnityEngine.Audio;

namespace RedPanda.AudioSystem.UserInterface
{
    [CreateAssetMenu(fileName = "AudioSlider", menuName = "Red Panda/Audio/Ui/Audio Slider")]
    public class SO_AudioSlider : ScriptableObject
    {
        #region Fields And Properties
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private string _exposedValueName = "masterVolume";
        #endregion Fields And Properties

        #region Unity Methods
        private void OnEnable()
        {
            if (_audioMixerGroup != null)
            {
                _audioMixerGroup.audioMixer.SetFloat(_exposedValueName, PlayerPrefs.GetFloat(_exposedValueName, 0f));
            }
        }
        #endregion Unity Methods

        #region Public Methods
        public void SliderValueChange(float value)
        {
            _audioMixerGroup.audioMixer.SetFloat(_exposedValueName, value);

            if (_audioMixerGroup != null)
            {
                PlayerPrefs.SetFloat(_exposedValueName, value);
            }
        }
        #endregion Public Methods
    }
}