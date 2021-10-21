using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ResourceDoubleMax : Resource
{
    [SerializeField] private int trueMaximum = 200;
    public int TrueMaximum
    {
        get { return trueMaximum; }
        //protected set { trueMaximum = value; }
    }

    public bool AddTrueMaximum(int amount)
    {
        if (amount <= 0) return false;
        if (CheckFullTrueMaximum()) return false;
        Value = Mathf.Clamp(Value, Value + amount, TrueMaximum);
        return true;
    }

    public bool CheckFullTrueMaximum()
    {
        return Value >= TrueMaximum;
    }
}

[CustomPropertyDrawer(typeof(ResourceDoubleMax))]
public class ResourceDoubleMaxDrawer : PropertyDrawer
{
    private readonly int valueWidth = 30;
    private readonly int separatorWidth = 10;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect value = new Rect(position.x, position.y, valueWidth, position.height);
        Rect separator1 = new Rect(value.x + value.width, position.y, separatorWidth, position.height);
        Rect maximum = new Rect(separator1.x + separator1.width, position.y, valueWidth, position.height);
        Rect separator2 = new Rect(maximum.x + maximum.width, position.y, separatorWidth, position.height);
        Rect trueMaximum = new Rect(separator2.x + separator2.width, position.y, valueWidth, position.height);
        EditorGUI.PropertyField(value, property.FindPropertyRelative("value"), GUIContent.none);
        GUI.Label(separator1, "/");
        EditorGUI.PropertyField(maximum, property.FindPropertyRelative("maximum"), GUIContent.none);
        GUI.Label(separator2, "/");
        EditorGUI.PropertyField(trueMaximum, property.FindPropertyRelative("trueMaximum"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
