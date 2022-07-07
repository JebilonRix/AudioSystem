using UnityEngine;
using UnityEngine.Audio;

namespace RedPanda.AudioSystem.UserInterface
{
    [CreateAssetMenu(fileName = "AudioToggleButton", menuName = "Red Panda/Audio/Ui/Toggle Button")]
    public class SO_AudioToggleButton : ScriptableObject
    {
        #region Fields And Properties
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private string _exposedValueName = "masterVolume";

        private bool _isPressed;
        #endregion Fields And Properties

        #region Unity Methods
        private void OnEnable()
        {
            _audioMixerGroup.audioMixer.SetFloat(_exposedValueName, PlayerPrefs.GetFloat(_exposedValueName, 0f));
        }
        private void OnDisable()
        {
            _isPressed = false;
        }
        #endregion Unity Methods

        #region Public Methods
        public void ToggleAudio()
        {
            _isPressed = !_isPressed;
            _audioMixerGroup.audioMixer.SetFloat(_exposedValueName, _isPressed ? 0.0f : -80.0f);
            PlayerPrefs.SetFloat(_exposedValueName, _isPressed ? 0.0f : -80.0f);
        }
        #endregion Public Methods
    }
}