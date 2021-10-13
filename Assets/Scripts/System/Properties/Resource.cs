using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Resource
{
    [SerializeField] private int value = 50;
    public int Value
    {
        get { return value; }
        protected set { this.value = value; }
    }

    [SerializeField] private int maximum = 100;
    public int Maximum
    {
        get { return maximum; }
        //protected set { maximum = value; }
    }

    [SerializeField] private int trueMaximum = 100;
    public int TrueMaximum
    {
        get { return trueMaximum; }
        //protected set { trueMaximum = value; }
    }

    public bool Add(int amount, bool trueMaximum)
    {
        if (amount <= 0) return false;
        if (CheckFull(trueMaximum)) return false;
        int maximum = trueMaximum ? TrueMaximum : Maximum;
        Value = Mathf.Clamp(Value, Value + amount, maximum);
        return true;
    }
    
    public bool Subtract(int amount, bool mustHaveEnough)
    {
        if (amount <= 0) return false;
        if (CheckEmpty()) return false;
        if (mustHaveEnough && Value < amount) return false;
        Value = Mathf.Clamp(Value, 0, Value - amount);
        return true;
    }

    public bool CheckFull(bool trueMaximum)
    {
        if (trueMaximum) return Value >= TrueMaximum;
        else return Value >= Maximum;
    }

    public bool CheckEmpty()
    {
        return Value <= 0;
    }
}

[CustomPropertyDrawer(typeof(Resource))]
public class ResourceDrawer : PropertyDrawer
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
