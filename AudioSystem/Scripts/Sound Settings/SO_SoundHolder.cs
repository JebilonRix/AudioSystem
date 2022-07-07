using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.AudioSystem
{
    [CreateAssetMenu(fileName = "Sound", menuName = "RedPanda/Sounds")]
    public class SO_SoundHolder : ScriptableObject
    {
        [SerializeField] private List<SingleSound> singleSounds = new List<SingleSound>();
        [SerializeField] private List<MultiSound> multiSounds = new List<MultiSound>();

        public void Play(AudioSource source, string tag, bool randomSound)
        {
            if (randomSound)
            {
                foreach (var item in multiSounds)
                {
                    if (item.tag != tag)
                    {
                        Debug.Log(item.tag + " is skipped.");
                        continue;
                    }

                    if (item.settings != null)
                    {
                        item.settings.Settings(source);
                    }

                    source.clip = item.clips[Random.Range(0, item.clips.Length)];
                    break;
                }
            }
            else
            {
                foreach (var item in singleSounds)
                {
                    if (item.tag != tag)
                    {
                        Debug.Log(item.tag + " is skipped.");
                        continue;
                    }

                    if (item.settings != null)
                    {
                        item.settings.Settings(source);
                    }

                    source.clip = item.clip;
                    break;
                }
            }

            source.Play();
        }
        public void Stop(AudioSource source)
        {
            source.Stop();
        }
    }
}