using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : AbstractPickup
{
    [SerializeField] private int amount;
    [SerializeField] private bool trueMaximum;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        if (trueMaximum) return mainCharacter.AddHealthTrueMax(amount);
        else return mainCharacter.AddHealth(amount);
    }
}
