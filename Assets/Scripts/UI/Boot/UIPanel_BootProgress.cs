using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel_BootProgress : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image progressFillImage;

    [Header("Text")]
    [SerializeField] private Text progressPercentText;
    //[SerializeField] private Text pressToContinueText;

    public void ManualUpdate(int percent)
    {
        float percentFactor = percent / 100F;
        string percentString = percent.ToString() + "%";
        progressFillImage.fillAmount = percentFactor;
        progressPercentText.text = percentString;
    }
}
