
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SelfRotate))]
public class SelfRotateEditor : Editor
{
    private SerializedProperty isRandom;
    private SerializedProperty tumble;
    private SerializedProperty rotateAxis;
    private SerializedProperty rotateSpeed;

    private void OnEnable()
    {
        isRandom = serializedObject.FindProperty("isRandom");
        tumble= serializedObject.FindProperty("tumble");
        rotateAxis= serializedObject.FindProperty("rotateAxis");
        rotateSpeed= serializedObject.FindProperty("rotateSpeed");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.PropertyField(isRandom, new GUIContent("IsRandom"));

        if (isRandom.boolValue)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(tumble, new GUIContent("Tumble"));
            EditorGUI.indentLevel--;
        }
        else
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(rotateAxis, new GUIContent("RotateAxis"));
            EditorGUILayout.PropertyField(rotateSpeed, new GUIContent("RotateSpeed"));
            EditorGUI.indentLevel--;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
