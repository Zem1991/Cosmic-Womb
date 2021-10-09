using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    [Header("Armor")]
    [SerializeField] private Resource armor;

    public int GetCurrentArmor()
    {
        return armor.Maximum;
    }

    public int GetMaximumArmor()
    {
        return armor.Maximum;
    }

    public bool CheckNoArmor()
    {
        return armor.CheckEmpty();
    }
    
    public bool CheckFullArmor()
    {
        return armor.CheckFull();
    }

    public bool LoseArmor(int amount)
    {
        if (amount <= 0) return false;
        return armor.Subtract(amount);
    }

    public bool GainArmor(int amount, bool isIncrease)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;

        if (isIncrease)
            return armor.Increase(amount);
        else
            return armor.Add(amount);
    }

    public bool GainArmorPercent(int percent)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        return armor.AddPercent(percent);
    }
}
