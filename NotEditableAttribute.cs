using UnityEngine;
using System;
using UnityEditor;

namespace GetOutStudio
{
    [AttributeUsage(AttributeTargets.Field)]
    public class NotEditableAttribute : PropertyAttribute { }

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
}