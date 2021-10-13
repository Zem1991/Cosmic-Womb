using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    [Header("Armor")]
    [SerializeField] private Resource armor;

    public int GetArmorCurrent()
    {
        return armor.Value;
    }

    public int GetArmorMax()
    {
        return armor.Maximum;
    }

    public bool CheckNoArmor()
    {
        return armor.CheckEmpty();
    }
    
    public bool CheckFullArmor(bool trueMaximum)
    {
        return armor.CheckFull(trueMaximum);
    }

    public bool AddArmor(int amount, bool trueMaximum)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        return armor.Add(amount, trueMaximum);
    }

    private bool SubtractArmor(int amount)
    {
        if (amount <= 0) return false;
        return armor.Subtract(amount, false);
    }
}
