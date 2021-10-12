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
    //[SerializeField] private Text grenadeCounterText;
    //[SerializeField] private Text keyCounterText;
    //[SerializeField] private Text medalCounterText;

    public void ManualUpdate(PlayerCharacter playerCharacter)
    {
        if (playerCharacter)
        {
            //int maxConsumables = MainCharacter.MAX_CONSUMABLES;

            int healthCurrent = playerCharacter.GetHealthCurrent();
            int healthMax = playerCharacter.GetHealthMax();

            float hpFillAmount = 1F * healthCurrent / healthMax;
            hpBarFillImage.fillAmount = hpFillAmount;

            Weapon weapon = playerCharacter.GetWeapon();
            Sprite weaponSprite = null;
            string ammoText = null;

            if (weapon)
            {
                AmmoType ammoType = weapon.GetAmmoType();
                int ammoCurrent = playerCharacter.GetAmmoCurrent(ammoType);
                int ammoMax = playerCharacter.GetAmmoMax(ammoType);

                weaponSprite = weapon.GetEquipmentSprite();

                if (weapon.NeedsAmmo())
                    ammoText = ammoCurrent + " / " + ammoMax;
                else
                    ammoText = "∞";
            }

            weaponImage.sprite = weaponSprite;
            weaponAmmoText.text = ammoText;

            //int grenadeCounter = playerCharacter.GetGrenadeCounter();
            //grenadeCounterText.text = grenadeCounter.ToString();

            //int keyCounter = playerCharacter.GetKeyCounter();
            //keyCounterText.text = keyCounter.ToString();

            //int medalCounter = playerCharacter.GetMedalCounter();
            //medalCounterText.text = medalCounter.ToString();
        }
        gameObject.SetActive(playerCharacter);
    }
}
