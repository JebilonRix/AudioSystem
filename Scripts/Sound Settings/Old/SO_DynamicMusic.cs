using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.AudioSystem
{
    [CreateAssetMenu(fileName = "DynamicMusic", menuName = "Red Panda/Audio/Dynamic Music")]
    public class SO_DynamicMusic : SO_BaseAudioSettings
    {
        #region Fields
        [Header("Clips")]
        [SerializeField] private AudioClip[] _clips;

        private Queue<int> _playQueue = new Queue<int>();
        private bool _isPlaying = false;
        private int _lastIndex = 0;
        #endregion Fields

        #region Unity Methods
        private void OnEnable()
        {
            _isPlaying = false;
            _lastIndex = 0;
        }
        #endregion Unity Methods

        #region Public Methods
        public void PlayDynamic(AudioSource source, int index)
        {
            if (_isPlaying)
            {
                //Debug.Log("to queue");
                _playQueue.Enqueue(index);
                return;
            }
            else
            {
                //Debug.Log("play");
                _lastIndex = index;
                PlayAudio(source);
                source.GetComponent<MonoBehaviour>().StartCoroutine(PlayTimer(source, _clips[_lastIndex].length));
            }
        }
        public override void PlayAudio(AudioSource source)
        {
            if (_clips == null)
            {
                return;
            }

            if (source.outputAudioMixerGroup == null)
            {
                source.outputAudioMixerGroup = _outputMixerGroup;
            }

            source.bypassEffects = _byPassEffects;
            source.clip = _clips[_lastIndex];
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
            source.GetComponent<MonoBehaviour>().StopAllCoroutines();

            //This is for clearing the queue.
            _playQueue.Clear();
            _lastIndex = 0;
            _isPlaying = false;
        }
        #endregion Public Methods

        #region Private Methods
        private IEnumerator PlayTimer(AudioSource source, float seconds)
        {
            _isPlaying = true;

            yield return new WaitForSeconds(seconds);

            _isPlaying = false;

            //source.Stop();

            if (_playQueue.Count > 0)
            {
                PlayDynamic(source, _playQueue.Dequeue());
            }
            else if (_playQueue.Count == 0)
            {
                PlayDynamic(source, _lastIndex);
            }
        }
        #endregion Private Methods
    }
}