#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public sealed class BlackboardKeysWindow : EditorWindow
{
    private SerializedProperty _names;

    private SerializedObject _serializedObject;

    private Vector2 _scrollPosition;

    private void Awake()
    {
        var config = BlackboardKeysConfig.EditorInstance;
        _serializedObject = new SerializedObject(config);
        _names = _serializedObject.FindProperty(nameof(_names));

        DrawTitle();
    }

    private void DrawTitle()
    {
        titleContent = new GUIContent("Blackboard Keys");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(8);

        EditorGUILayout.BeginVertical();
        _scrollPosition = EditorGUILayout.BeginScrollView(
            _scrollPosition,
            GUILayout.ExpandWidth(true),
            GUILayout.ExpandHeight(true)
        );

        if (_names != null)
        {
            EditorGUILayout.PropertyField(_names, includeChildren: true);
        }


        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        if (_serializedObject != null)
        {
            _serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif