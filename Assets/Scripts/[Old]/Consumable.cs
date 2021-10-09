using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public const int MAX_CONSUMABLES = 99;

    [Header("Identification")]
    [SerializeField] private string consumableName;
    [SerializeField] private Sprite consumableSprite;
    [SerializeField] private ConsumableType consumableType;

    [Header("Quantity")]
    [SerializeField] private int quantity;

    #region Identification
    public string GetConsumableName()
    {
        return consumableName;
    }
    public Sprite GetConsumableSprite()
    {
        return consumableSprite;
    }
    public ConsumableType GetConsumableType()
    {
        return consumableType;
    }
    #endregion

    #region Quantity
    public int GetQuantity()
    {
        return quantity;
    }
    public bool Add(int amount = 1)
    {
        if (amount <= 0) return false;
        if (quantity + amount > MAX_CONSUMABLES) return false;
        quantity += amount;
        return true;
    }
    public bool Subtract(int amount = 1)
    {
        if (amount <= 0) return false;
        if (quantity - amount < 0) return false;
        quantity -= amount;
        return true;
    }
    #endregion
}
