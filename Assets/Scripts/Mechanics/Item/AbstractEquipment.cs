using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEquipment : MonoBehaviour
{
    [Header("Identification")]
    [SerializeField] private string equipmentName;
    [SerializeField] private Sprite equipmentSprite;

    #region Identification
    public string GetEquipmentName()
    {
        return equipmentName;
    }

    public Sprite GetEquipmentSprite()
    {
        return equipmentSprite;
    }
    #endregion
}
