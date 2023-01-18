#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;


public sealed class UnityEntityProxyEditor : Editor
{
    private SerializedProperty _entity;
    private MonoBehaviour[] _elements;
    private IEntity _proxy;

    private void Awake()
    {
        _entity = serializedObject.FindProperty(nameof(_entity));
        _proxy = (IEntity)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.Space(2);
        EditorGUILayout.PropertyField(_entity);
        serializedObject.ApplyModifiedProperties();

        GUI.enabled = false;

        try
        {
            DrawElements();
        }
        catch (Exception)
        {
        }

        GUI.enabled = true;

    }

    private void DrawElements()
    {
        EditorGUILayout.Space(4);
        _elements = _proxy.GetAll<MonoBehaviour>();

        foreach (var element in _elements)
        {
            EditorGUILayout.ObjectField(obj: element, objType: typeof(MonoBehaviour), allowSceneObjects: true);
        }
    }
}

#endif