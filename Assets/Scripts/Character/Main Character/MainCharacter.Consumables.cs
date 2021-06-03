using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainCharacter : Character
{
    public const int MAX_CONSUMABLES = 99;

    [Header("Consumables")]
    [SerializeField] private int grenadeCounter;
    [SerializeField] private int keyCounter;
    [SerializeField] private int medalCounter;

    public int GetGrenadeCounter()
    {
        return grenadeCounter;
    }

    public int GetKeyCounter()
    {
        return keyCounter;
    }

    public int GetMedalCounter()
    {
        return medalCounter;
    }

    public bool AddConsumable(Consumable consumablePrefab, int amount = 1)
    {
        if (amount <= 0) return false;
        ConsumableType consumableType = consumablePrefab.GetConsumableType();
        switch (consumableType)
        {
            case ConsumableType.GRENADE:
                if (grenadeCounter >= MAX_CONSUMABLES) return false;
                grenadeCounter = Mathf.Clamp(grenadeCounter + amount, 0, MAX_CONSUMABLES);
                break;
            case ConsumableType.KEY:
                if (keyCounter >= MAX_CONSUMABLES) return false;
                keyCounter = Mathf.Clamp(keyCounter + amount, 0, MAX_CONSUMABLES);
                break;
            case ConsumableType.MEDAL:
                if (medalCounter >= MAX_CONSUMABLES) return false;
                medalCounter = Mathf.Clamp(medalCounter + amount, 0, MAX_CONSUMABLES);
                break;
        }
        return true;
    }

    public bool SubtractConsumable(ConsumableType consumableType, int amount = 1)
    {
        if (amount <= 0) return false;

        switch (consumableType)
        {
            case ConsumableType.GRENADE:
                if (grenadeCounter - amount < 0) return false;
                grenadeCounter = Mathf.Clamp(grenadeCounter - amount, 0, MAX_CONSUMABLES);
                break;
            case ConsumableType.KEY:
                if (keyCounter - amount < 0) return false;
                keyCounter = Mathf.Clamp(keyCounter - amount, 0, MAX_CONSUMABLES);
                break;
            case ConsumableType.MEDAL:
                if (medalCounter - amount < 0) return false;
                medalCounter = Mathf.Clamp(medalCounter - amount, 0, MAX_CONSUMABLES);
                break;
        }
        return true;
    }
}
