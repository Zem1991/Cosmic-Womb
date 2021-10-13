using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEffect : AbstractEffect
{
    [Header("Health")]
    [SerializeField] private int amount;
    [SerializeField] private bool trueMaximum;
    //[SerializeField] private bool isIncrease;
    //[SerializeField] private bool isPercent;

    public override bool Apply(AbstractCharacter target)
    {
        return target.AddHealth(amount, trueMaximum);
    }
}
