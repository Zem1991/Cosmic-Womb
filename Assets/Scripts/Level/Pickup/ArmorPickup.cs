using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : AbstractPickup
{
    [SerializeField] private int amount;
    [SerializeField] private bool trueMaximum;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        return mainCharacter.AddArmor(amount, trueMaximum);
    }
}
