using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : AbstractPickup
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int amount;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        return mainCharacter.AddAmmo(ammoType, amount);
    }
}
