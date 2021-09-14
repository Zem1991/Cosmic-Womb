using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOffer : MonoBehaviour
{
    [Header("Quality")]
    [SerializeField] private int qualityLevel;

    [Header("Availability")]
    [SerializeField] private int weight = 10;
    [SerializeField] private bool wasOffered;
    [SerializeField] private bool wasChosen;

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
    #endregion

    public int CalculateAvailability()
    {
        int result = weight;
        if (wasOffered) result /= 2;
        if (wasChosen) result = 0;
        return result;
    }
}
