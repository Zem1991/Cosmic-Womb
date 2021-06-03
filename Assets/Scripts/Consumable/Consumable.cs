using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [Header("Identification")]
    [SerializeField] private string consumableName;
    [SerializeField] private Sprite consumableSprite;
    [SerializeField] private ConsumableType consumableType;

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
}
