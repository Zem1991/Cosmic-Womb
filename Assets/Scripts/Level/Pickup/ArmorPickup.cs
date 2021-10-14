using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : AbstractPickup
{
    [SerializeField] private int amount;
    [SerializeField] private bool trueMaximum;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        if (trueMaximum) return mainCharacter.AddArmorTrueMax(amount);
        else return mainCharacter.AddArmor(amount);
    }
}
