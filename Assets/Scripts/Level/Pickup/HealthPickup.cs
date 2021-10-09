using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : AbstractPickup
{
    [SerializeField] private int amount;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        return mainCharacter.GainHealth(amount, false);
    }
}
