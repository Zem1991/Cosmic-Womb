using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    [Header("Consumables")]
    [SerializeField] private Transform consumablesHolder;
    [SerializeField] private List<Consumable> consumableList = new List<Consumable>();
    [SerializeField] private Consumable grenadeConsumable;
    [SerializeField] private Consumable keyConsumable;
    [SerializeField] private Consumable medalConsumable;

    //[SerializeField] private int grenadeCounter;
    //[SerializeField] private int keyCounter;
    //[SerializeField] private int medalCounter;

    public int GetGrenadeCounter()
    {
        return grenadeConsumable.GetQuantity();
    }

    public int GetKeyCounter()
    {
        return keyConsumable.GetQuantity();
    }

    public int GetMedalCounter()
    {
        return medalConsumable.GetQuantity();
    }

    public bool AddConsumable(Consumable consumablePrefab, int amount = 1)
    {
        if (amount <= 0) return false;

        Consumable listedCons = null;
        foreach (Consumable forCons in consumableList)
        {
            if (forCons.GetConsumableType() != consumablePrefab.GetConsumableType()) continue;
            listedCons = forCons;
            break;
        }

        if (!listedCons)
        {
            listedCons = Instantiate(consumablePrefab, consumablesHolder);
            bool success = listedCons.Add(amount);
            if (success)
            {
                consumableList.Add(listedCons);
            }
            else
            {
                Destroy(listedCons.gameObject);
            }
            return success;
        }
        else
        {
            return listedCons.Add(amount);
        }
    }

    public bool SubtractConsumable(Consumable consumablePrefab, int amount = 1)
    {
        if (amount <= 0) return false;

        Consumable listedCons = null;
        foreach (Consumable forCons in consumableList)
        {
            if (forCons.GetConsumableType() != consumablePrefab.GetConsumableType()) continue;
            listedCons = forCons;
            break;
        }

        if (!listedCons) return false;
        return listedCons.Subtract(amount);
    }
}
