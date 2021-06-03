using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablePickup : Pickup
{
    [SerializeField] private Consumable consumablePrefab;
    [SerializeField] private int amount;

    private void OnTriggerEnter(Collider other)
    {
        MainCharacter mainCharacter = other.GetComponent<MainCharacter>();
        if (mainCharacter)
        {
            bool added = mainCharacter.AddConsumable(consumablePrefab, amount);
            if (added) Destroy(gameObject);
        }
    }
}
