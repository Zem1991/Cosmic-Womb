using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponPrefab;

    private void OnTriggerEnter(Collider other)
    {
        MainCharacter mainCharacter = other.GetComponent<MainCharacter>();
        if (mainCharacter)
        {
            bool weaponAdded = mainCharacter.AddWeapon(weaponPrefab);
            if (weaponAdded) Destroy(gameObject);
        }
    }
}
