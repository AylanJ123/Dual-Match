#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.UI;

namespace MinigamesScripts
{
    [CustomEditor(typeof(GameButton))]
    public class GameButtonDrawer : ButtonEditor
    {
        private SerializedProperty enter;
        private SerializedProperty stay;
        private SerializedProperty release;

        protected override void OnEnable()
        {
            base.OnEnable();
            enter = serializedObject.FindProperty("OnEnter");
            stay = serializedObject.FindProperty("OnStay");
            release = serializedObject.FindProperty("OnRelease");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.PropertyField(enter, true, null);
            EditorGUILayout.PropertyField(stay, true, null);
            EditorGUILayout.PropertyField(release, true, null);
            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif