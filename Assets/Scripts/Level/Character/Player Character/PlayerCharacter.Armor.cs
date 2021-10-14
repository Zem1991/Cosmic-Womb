using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    [Header("Armor")]
    [SerializeField] private ResourceDoubleMax armor;

    public int GetArmorCurrent()
    {
        return armor.Value;
    }

    public int GetArmorMax()
    {
        return armor.Maximum;
    }

    public int GetArmorTrueMax()
    {
        return armor.TrueMaximum;
    }

    public bool CheckNoArmor()
    {
        return armor.CheckEmpty();
    }
    
    public bool CheckFullArmor()
    {
        return armor.CheckFull();
    }

    public bool CheckFullArmorTrueMax()
    {
        return armor.CheckFullTrueMaximum();
    }

    public bool AddArmor(int amount)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        return armor.Add(amount);
    }

    public bool AddArmorTrueMax(int amount)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        return armor.AddTrueMaximum(amount);
    }

    private bool SubtractArmor(int amount)
    {
        if (amount <= 0) return false;
        return armor.Subtract(amount, false);
    }
}
