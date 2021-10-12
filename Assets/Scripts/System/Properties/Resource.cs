using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Resource
{
    [SerializeField] private int value = 10;
    public int Value
    {
        get { return value; }
        private set { this.value = value; }
    }

    [SerializeField] private int maximum = 15;
    public int Maximum
    {
        get { return maximum; }
        private set { maximum = value; }
    }

    //public bool Increase(int amount)
    //{
    //    Value += amount;
    //    Maximum += amount;
    //    return true;
    //}
    
    public bool Add(int amount)
    {
        if (amount <= 0) return false;
        if (CheckFull()) return false;
        Value = Mathf.Clamp(Value, Value + amount, Value);
        return true;
    }

    //public bool AddPercent(int percent)
    //{
    //    percent = Mathf.Clamp(percent, 0, 100);
    //    float percentFloat = percent / 100F;
    //    percentFloat *= maximum;
    //    int amount = Mathf.FloorToInt(percentFloat);
    //    return Add(amount);
    //}

    public bool Subtract(int amount, bool mustHaveEnough = false)
    {
        if (amount <= 0) return false;
        if (CheckEmpty()) return false;
        if (mustHaveEnough && Value < amount) return false;
        Value = Mathf.Clamp(Value, 0, Value - amount);
        return true;
    }

    public bool CheckFull()
    {
        return Value >= Maximum;
    }

    public bool CheckEmpty()
    {
        return Value <= 0;
    }
}

[CustomPropertyDrawer(typeof(Resource))]
public class ResourceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect valueRect = new Rect(position.x, position.y, 40, position.height);
        Rect separatorRect = new Rect(valueRect.x + valueRect.width, position.y, 10, position.height);
        Rect maximumRect = new Rect(separatorRect.x + separatorRect.width, position.y, 40, position.height);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
        GUI.Label(separatorRect, "/");
        EditorGUI.PropertyField(maximumRect, property.FindPropertyRelative("maximum"), GUIContent.none);
        
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
