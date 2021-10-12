using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    [Header("Equipment")]
    [SerializeField] private Transform equipmentHolder;
    [SerializeField] private Equipment equipment;
    [SerializeField] private List<Equipment> equipmentList = new List<Equipment>();

    public void SelectPreviousEquipment()
    {
        if (!equipment)
        {
            SetEquipment(0);
            return;
        }
        int index = equipmentList.IndexOf(equipment) - 1;
        SetEquipment(index);
    }

    public void SelectNextEquipment()
    {
        if (!equipment)
        {
            SetEquipment(0);
            return;
        }
        int index = equipmentList.IndexOf(equipment) + 1;
        SetEquipment(index);
    }

    private void SetEquipment(int index)
    {
        if (equipmentList.Count <= 0)
        {
            equipment = null;
            return;
        }
        if (index < 0) index = equipmentList.Count - 1;
        if (index >= equipmentList.Count) index = 0;
        SetEquipment(equipmentList[index]);
    }

    private void SetEquipment(Equipment equipment)
    {
        this.equipment = equipment;
    }

    public bool GiveEquipment(Equipment prefab)
    {
        //TODO check for repeated equipment
        Equipment newEquipment = Instantiate(prefab, equipmentHolder);
        equipmentList.Add(newEquipment);
        return true;
    }

    //public bool AddConsumable(Consumable consumablePrefab, int amount = 1)
    //{
    //    if (amount <= 0) return false;

    //    Consumable listedCons = null;
    //    foreach (Consumable forCons in consumableList)
    //    {
    //        if (forCons.GetConsumableType() != consumablePrefab.GetConsumableType()) continue;
    //        listedCons = forCons;
    //        break;
    //    }

    //    if (!listedCons)
    //    {
    //        listedCons = Instantiate(consumablePrefab, consumablesHolder);
    //        bool success = listedCons.Add(amount);
    //        if (success)
    //        {
    //            consumableList.Add(listedCons);
    //        }
    //        else
    //        {
    //            Destroy(listedCons.gameObject);
    //        }
    //        return success;
    //    }
    //    else
    //    {
    //        return listedCons.Add(amount);
    //    }
    //}

    //public bool SubtractConsumable(Consumable consumablePrefab, int amount = 1)
    //{
    //    if (amount <= 0) return false;

    //    Consumable listedCons = null;
    //    foreach (Consumable forCons in consumableList)
    //    {
    //        if (forCons.GetConsumableType() != consumablePrefab.GetConsumableType()) continue;
    //        listedCons = forCons;
    //        break;
    //    }

    //    if (!listedCons) return false;
    //    return listedCons.Subtract(amount);
    //}
}
