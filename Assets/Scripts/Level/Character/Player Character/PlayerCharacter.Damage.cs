using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    public override bool TakeDamage(int amount)
    {
        //TODO: Armor works like in doom, where 1/3 of received damage is reduced from armor and the other 2/3 is reduced from health.
        //TODO: strangely on Doom the Megaarmor, while more protective, depletes faster than normal armor. Right?

        int reduction = 3;
        int reduced = amount / reduction;
        int remainder = amount % reduction;

        int armor = GetArmorCurrent();
        int armorDamage = reduced;
        int armorLeftover = (armor - armorDamage) * -1;
        SubtractArmor(armorDamage);

        int healthDamage = reduced * 2;
        healthDamage += remainder;
        if (armorLeftover > 0) healthDamage += armorLeftover;
        return base.TakeDamage(healthDamage);
    }
}
