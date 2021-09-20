using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class IntProperty
{
    [SerializeField] private int value = 10;
    public int Value
    {
        get { return value; }
        private set { this.value = value; }
    }
    
    public void Add(int amount)
    {
        if (amount < 0) return;
        Value += amount;
    }

    public void Subtract(int amount)
    {
        if (amount < 0) return;
        Value -= amount;
    }
}

[CustomPropertyDrawer(typeof(IntProperty))]
public class IntPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect valueRect = new Rect(position.x, position.y, 90, position.height);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
        
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
