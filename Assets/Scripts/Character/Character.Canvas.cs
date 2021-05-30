using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Character : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private Image hpBarFill;

    private void UpdateCanvas()
    {
        if (hpBarFill)
        {
            float currentHP = GetCurrentHealth();
            float maxHP = GetMaximumHealth();
            float fillAmount = currentHP / maxHP;
            hpBarFill.fillAmount = fillAmount;
        }
    }
}
