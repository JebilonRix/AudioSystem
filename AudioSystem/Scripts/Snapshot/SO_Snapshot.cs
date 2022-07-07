using UnityEngine;
using UnityEngine.Audio;

namespace RedPanda.AudioSystem.AudioSettings
{
    [CreateAssetMenu(fileName = "Snapshot", menuName = "Red Panda/Audio/Snapshot")]
    public class SO_Snapshot : ScriptableObject
    {
        #region Fields
        [SerializeField] private SnapshotClass[] _snapshots;
        #endregion Fields

        #region Public Methods
        public void DoSnapshot(string tag)
        {
            foreach (SnapshotClass shot in _snapshots)
            {
                if (shot.tag == tag)
                {
                    shot.snapshot.TransitionTo(shot.snapshotTime);
                    break;
                }
            }
        }
        #endregion Public Methods
    }

    [System.Serializable]
    internal struct SnapshotClass
    {
        public string tag;
        public AudioMixerSnapshot snapshot;
        public float snapshotTime;
    }
}