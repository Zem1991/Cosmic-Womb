using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel_PlayerData : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image hpBarFillImage;
    [SerializeField] private Image weaponImage;

    [Header("Text")]
    [SerializeField] private Text weaponAmmoText;
    [SerializeField] private Text grenadeCounterText;
    [SerializeField] private Text keyCounterText;
    [SerializeField] private Text medalCounterText;

    public void ManualUpdate(PlayerCharacter mainCharacter)
    {
        if (mainCharacter)
        {
            //int maxConsumables = MainCharacter.MAX_CONSUMABLES;

            float hpFillAmount = 1F * mainCharacter.GetCurrentHealth() / mainCharacter.GetMaximumHealth();
            hpBarFillImage.fillAmount = hpFillAmount;

            Weapon mcWeapon = mainCharacter.GetWeapon();
            weaponImage.sprite = mcWeapon.GetWeaponSprite();

            if (mcWeapon.HasInfiniteAmmo())
            {
                weaponAmmoText.text = "∞";
            }
            else
            {
                int ammunitionCurrent = mcWeapon.GetAmmunitionCurrent();
                int ammunitionMax = mcWeapon.GetAmmunitionMax();
                weaponAmmoText.text = ammunitionCurrent + " / " + ammunitionMax;
            }

            int grenadeCounter = mainCharacter.GetGrenadeCounter();
            grenadeCounterText.text = grenadeCounter.ToString();

            int keyCounter = mainCharacter.GetKeyCounter();
            keyCounterText.text = keyCounter.ToString();

            int medalCounter = mainCharacter.GetMedalCounter();
            medalCounterText.text = medalCounter.ToString();
        }
        gameObject.SetActive(mainCharacter);
    }
}
