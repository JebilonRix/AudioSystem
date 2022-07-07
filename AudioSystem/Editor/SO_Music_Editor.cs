using UnityEditor;
using UnityEngine;

namespace RedPanda.AudioSystem.AudioEditor
{
    [CustomEditor(typeof(SO_Music))]
    public class SO_Music_Editor : Editor
    {
        #region Fields
        private AudioSource _previewer;
        #endregion Fields

        #region Unity Methods
        private void OnEnable()
        {
            _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
        }
        private void OnDisable()
        {
            DestroyImmediate(_previewer.gameObject);
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SO_Music music = (SO_Music)target;

            if (GUILayout.Button("Preview"))
            {
                if (music.Clip != null)
                {
                    music.PlayAudio(_previewer);
                    //_previewer.PlayOneShot(music.Clip);
                }
            }
            if (GUILayout.Button("Stop"))
            {
                music.StopAudio(_previewer);
            }
        }

        #endregion Unity Methods
    }
}