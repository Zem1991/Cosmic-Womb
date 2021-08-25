using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICrosshair : MonoBehaviour
{
    [SerializeField] private Image crosshair;
    [SerializeField] private Image charge;

    public void ManualUpdate(Vector2 screenPosition, Sprite crosshairImg, float chargeAmount)
    {
        transform.position = screenPosition;
        crosshair.sprite = crosshairImg;
        charge.fillAmount = chargeAmount;
    }
}
