using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
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

    public int GetAmmoCurrent(AmmoType ammoType)
    {
        switch (ammoType)
        {
            case AmmoType.BULLET:
                return bullets.Value;
            case AmmoType.SHELL:
                return shells.Value;
            case AmmoType.ROCKET:
                return rockets.Value;
            case AmmoType.CELL:
                return cells.Value;
            case AmmoType.RICOS:
                return ricos.Value;
            case AmmoType.FLAMES:
                return flames.Value;
            case AmmoType.TESLAS:
                return teslas.Value;
            case AmmoType.CHAINS:
                return chains.Value;
        }
        return -1;
    }

    public int GetAmmoMax(AmmoType ammoType)
    {
        switch (ammoType)
        {
            case AmmoType.BULLET:
                return bullets.Maximum;
            case AmmoType.SHELL:
                return shells.Maximum;
            case AmmoType.ROCKET:
                return rockets.Maximum;
            case AmmoType.CELL:
                return cells.Maximum;
            case AmmoType.RICOS:
                return ricos.Maximum;
            case AmmoType.FLAMES:
                return flames.Maximum;
            case AmmoType.TESLAS:
                return teslas.Maximum;
            case AmmoType.CHAINS:
                return chains.Maximum;
        }
        return -1;
    }

    public bool AddAmmo(AmmoType ammoType, int amount)
    {
        switch (ammoType)
        {
            case AmmoType.BULLET:
                return bullets.Add(amount, false);
            case AmmoType.SHELL:
                return shells.Add(amount, false);
            case AmmoType.ROCKET:
                return rockets.Add(amount, false);
            case AmmoType.CELL:
                return cells.Add(amount, false);
            case AmmoType.RICOS:
                return ricos.Add(amount, false);
            case AmmoType.FLAMES:
                return flames.Add(amount, false);
            case AmmoType.TESLAS:
                return teslas.Add(amount, false);
            case AmmoType.CHAINS:
                return chains.Add(amount, false);
        }
        return false;
    }

    private bool SubtractAmmo(AmmoType ammoType, int amount)
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
