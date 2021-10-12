using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    [Header("Weapons")]
    [SerializeField] private Transform weaponsHolder;
    [SerializeField] private Weapon weapon;
    [SerializeField] private List<Weapon> weaponList = new List<Weapon>();

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public bool GiveWeapon(Weapon prefab)
    {
        //TODO check for repeated weapons
        Weapon newWeapon = Instantiate(prefab, weaponsHolder);
        weaponList.Add(newWeapon);
        return true;
    }

    public void SelectPreviousWeapon()
    {
        if (!weapon)
        {
            SetWeapon(0);
            return;
        }
        int index = weaponList.IndexOf(weapon) - 1;
        SetWeapon(index);
    }

    public void SelectNextWeapon()
    {
        if (!weapon)
        {
            SetWeapon(0);
            return;
        }
        int index = weaponList.IndexOf(weapon) + 1;
        SetWeapon(index);
    }

    private void SetWeapon(int index)
    {
        if (weaponList.Count <= 0)
        {
            this.weapon = null;
            return;
        }

        if (index < 0) index = weaponList.Count - 1;
        if (index >= weaponList.Count) index = 0;
        Weapon weapon = weaponList[index];
        SetWeapon(weapon);
    }

    private void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        attack = weapon.GetAttack();
    }
}
