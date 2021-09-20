using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : AbstractPickup
{
    [SerializeField] private int amount;

    private void OnTriggerEnter(Collider other)
    {
        MainCharacter mainCharacter = other.GetComponent<MainCharacter>();
        if (mainCharacter)
        {
            bool added = mainCharacter.GainHealth(amount, false);
            if (added) Destroy(gameObject);
        }
    }
}
