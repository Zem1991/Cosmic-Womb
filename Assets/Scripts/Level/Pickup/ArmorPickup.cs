using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : AbstractPickup
{
    [SerializeField] private int amount;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        return mainCharacter.GainArmor(amount, false);
    }
}
