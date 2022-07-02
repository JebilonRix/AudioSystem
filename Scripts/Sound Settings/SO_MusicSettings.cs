using UnityEngine;

namespace RedPanda.AudioSystem
{
    [CreateAssetMenu(fileName = "MusicSettings", menuName = "Red Panda/Audio/Music Settings")]
    public class SO_MusicSettings : SO_Settings
    {
        [SerializeField] private bool _isLoop = true;

        public override void Settings(AudioSource source)
        {
            source.loop = _isLoop;
            base.Settings(source);
        }
    }
}