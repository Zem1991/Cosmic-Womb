using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainCharacter : Character
{
    [Header("Ammo")]
    [SerializeField] private Resource bullets;
    [SerializeField] private Resource shells;
    [SerializeField] private Resource rockets;
    [SerializeField] private Resource cells;
    [SerializeField] private Resource ricos;
    [SerializeField] private Resource flames;
    [SerializeField] private Resource teslas;
    [SerializeField] private Resource chains;

    public bool AddAmmo(AmmoType ammoType, int amount)
    {
        switch (ammoType)
        {
            case AmmoType.BULLET:
                return bullets.Add(amount);
            case AmmoType.SHELL:
                return shells.Add(amount);
            case AmmoType.ROCKET:
                return rockets.Add(amount);
            case AmmoType.CELL:
                return cells.Add(amount);
            case AmmoType.RICOS:
                return ricos.Add(amount);
            case AmmoType.FLAMES:
                return flames.Add(amount);
            case AmmoType.TESLAS:
                return teslas.Add(amount);
            case AmmoType.CHAINS:
                return chains.Add(amount);
        }
        return false;
    }

    public bool SubtractAmmo(AmmoType ammoType, int amount)
    {
        switch (ammoType)
        {
            case AmmoType.BULLET:
                return bullets.Subtract(amount, true);
            case AmmoType.SHELL:
                return shells.Subtract(amount, true);
            case AmmoType.ROCKET:
                return rockets.Subtract(amount, true);
            case AmmoType.CELL:
                return cells.Subtract(amount, true);
            case AmmoType.RICOS:
                return ricos.Subtract(amount, true);
            case AmmoType.FLAMES:
                return flames.Subtract(amount, true);
            case AmmoType.TESLAS:
                return teslas.Subtract(amount, true);
            case AmmoType.CHAINS:
                return chains.Subtract(amount, true);
        }
        return false;
    }
}
