using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOffer : MonoBehaviour
{
    [Header("Identification")]
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;

    [Header("Quality")]
    [SerializeField] private int qualityLevel;

    [Header("Availability")]
    [SerializeField] private int weight = 10;
    [SerializeField] private bool wasOffered;
    [SerializeField] private bool wasChosen;

    #region Identification
    public string GetTitle()
    {
        return title;
    }
    public string GetDescription()
    {
        return description;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    #endregion

    #region Quality
    public int GetQualityLevel()
    {
        return qualityLevel;
    }
    #endregion

    #region Availability
    public int GetWeight()
    {
        return weight;
    }
    public bool WasOffered()
    {
        return wasOffered;
    }
    public void SetOffered(bool value)
    {
        wasOffered = value;
    }
    public bool WasChosen()
    {
        return wasChosen;
    }
    public void SetChosen(bool value)
    {
        wasChosen = value;
    }
    public int CalculateAvailability()
    {
        int result = weight;
        if (wasOffered) result /= 2;
        if (wasChosen) result = 0;
        return result;
    }
    #endregion
}
