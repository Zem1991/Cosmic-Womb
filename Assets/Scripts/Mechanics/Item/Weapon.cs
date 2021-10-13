using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : AbstractEquipment
{
    [Header("Self references")]
    [SerializeField] private Attack attack;
    [SerializeField] private Sprite crosshair;

    [Header("Ammunition")]
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int ammoCost = 1;

    #region Self references
    public Attack GetAttack()
    {
        return attack;
    }
    public Sprite GetCrosshair()
    {
        return crosshair;
    }
    #endregion

    #region Ammunition
    public AmmoType GetAmmoType()
    {
        return ammoType;
    }
    public int GetAmmoCost()
    {
        return ammoCost;
    }
    public bool NeedsAmmo()
    {
        return ammoCost > 0;
    }
    #endregion
}
