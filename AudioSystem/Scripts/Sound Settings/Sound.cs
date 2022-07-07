using UnityEngine;

namespace RedPanda.AudioSystem
{
    public class Sound
    {
        public string tag;
        public SO_Settings settings;
    }

    [System.Serializable]
    public class SingleSound : Sound
    {
        public AudioClip clip;
    }

    [System.Serializable]
    public class MultiSound : Sound
    {
        public AudioClip[] clips;
    }
}