using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEffect : AbstractEffect
{
    [Header("Health")]
    [SerializeField] private int amount;
    [SerializeField] private bool isIncrease;
    [SerializeField] private bool isPercent;

    public override bool Apply(AbstractCharacter target)
    {
        if (isPercent)
            return target.GainHealthPercent(amount);
        else
            return target.GainHealth(amount, isIncrease);
    }
}
