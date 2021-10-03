using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOffer : MonoBehaviour
{
    [Header("Reward")]
    [SerializeField] private Reward reward;
    //TODO: replace the self identification fields for the Reward identification fields (I mean, copy and paste some values to other prefabs)
    [SerializeField] private string title;
    [SerializeField] [TextArea] private string description;
    [SerializeField] private Sprite sprite;

    [Header("Quality")]
    [SerializeField] private int qualityLevel;

    [Header("Availability")]
    [SerializeField] private int weight = 10;
    [SerializeField] private bool wasOffered;
    [SerializeField] private bool wasChosen;

    #region Reward
    public Reward GetReward()
    {
        return reward;
    }
    public string GetTitle()
    {
        return reward.GetTitle();
    }
    public string GetDescription()
    {
        return reward.GetDescription();
    }
    public Sprite GetSprite()
    {
        return reward.GetSprite();
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
