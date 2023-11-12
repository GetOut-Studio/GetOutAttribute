using UnityEngine;
using System;
using UnityEditor;

[AttributeUsage(AttributeTargets.Field)]
public class NotEditableAttribute : PropertyAttribute
{
    public bool HideInInspector = false;

    public void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Saving previous GUI enabled value
        var previousGUIState = GUI.enabled;
        // Disabling edit for property
        GUI.enabled = false;
        // Drawing Property
        EditorGUI.PropertyField(position, property, label);
        // Setting old GUI enabled value
        GUI.enabled = previousGUIState;
    }
}

[CustomPropertyDrawer(typeof(NotEditableAttribute))]
public class NotEditableDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var previousGUIState = GUI.enabled;
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = previousGUIState;
    }
}
