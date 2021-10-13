using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : AbstractPickup
{
    [SerializeField] private int amount;
    [SerializeField] private bool trueMaximum;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        return mainCharacter.AddHealth(amount, trueMaximum);
    }
}
