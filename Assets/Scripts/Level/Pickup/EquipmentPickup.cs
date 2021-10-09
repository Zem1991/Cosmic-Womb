using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPickup : AbstractPickup
{
    [SerializeField] private Equipment equipmentPrefab;

    protected override bool ApplyPickup(PlayerCharacter mainCharacter)
    {
        return mainCharacter.GiveEquipment(equipmentPrefab);
    }
}
