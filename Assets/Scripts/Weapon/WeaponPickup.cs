using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : AbstractPickup
{
    [SerializeField] private Weapon weaponPrefab;
    [SerializeField] private int ammo;

    private void OnTriggerEnter(Collider other)
    {
        MainCharacter mainCharacter = other.GetComponent<MainCharacter>();
        if (mainCharacter)
        {
            bool added = mainCharacter.AddWeapon(weaponPrefab);
            if (added) Destroy(gameObject);
        }
    }
}
