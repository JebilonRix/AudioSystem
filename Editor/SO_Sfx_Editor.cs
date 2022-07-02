using UnityEditor;
using UnityEngine;

namespace RedPanda.AudioSystem.AudioEditor
{
    [CustomEditor(typeof(SO_Sfx))]
    public class SO_Sfx_Editor : Editor
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

            SO_Sfx sfx = (SO_Sfx)target;

            if (GUILayout.Button("Preview"))
            {
                if (sfx.Clip != null)
                {
                    sfx.PlayAudio(_previewer);
                    // _previewer.PlayOneShot(sfx.Clip);
                }
            }
            if (GUILayout.Button("Stop"))
            {
                sfx.StopAudio(_previewer);
            }
        }
        #endregion Unity Methods
    }
}