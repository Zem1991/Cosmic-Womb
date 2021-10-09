using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablePickup : MonoBehaviour
{
    [SerializeField] private Consumable consumablePrefab;
    [SerializeField] private int amount;

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter mainCharacter = other.GetComponent<PlayerCharacter>();
        if (mainCharacter)
        {
            bool added = mainCharacter.AddConsumable(consumablePrefab, amount);
            if (added) Destroy(gameObject);
        }
    }
}
