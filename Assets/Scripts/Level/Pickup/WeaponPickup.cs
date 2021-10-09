using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : AbstractPickup
{
    [SerializeField] private Weapon weaponPrefab;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        return mainCharacter.GiveWeapon(weaponPrefab);
    }
}
