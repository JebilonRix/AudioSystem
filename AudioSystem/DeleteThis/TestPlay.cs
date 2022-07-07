using UnityEngine;

namespace RedPanda.AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class TestPlay : MonoBehaviour
    {
        public KeyCode key = KeyCode.F1;
        public SO_SoundHolder _holder;
        public string tag;
        public bool random;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(key))
            {
                _holder.Play(_audioSource, tag, random);
            }
        }
    }
}