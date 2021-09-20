using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoEffect : AbstractEffect
{
    [Header("Ammo")]
    [SerializeField] private AmmoType resourceType;
    [SerializeField] private int amount;

    public override bool Apply(Character target)
    {
        MainCharacter targetMC = target.GetComponent<MainCharacter>();
        if (!targetMC) return false;
        return targetMC.AddAmmo(resourceType, amount);
    }
}
