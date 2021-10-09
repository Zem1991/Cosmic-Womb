using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : SceneUI
{
    [Header("Panels - normal")]
    [SerializeField] private UICrosshair crosshair;
    [SerializeField] private UIPanel_PlayerData playerData;
    [SerializeField] private UIInteraction interaction;
    
    [Header("Panels - paused")]
    [SerializeField] private UIPanel_PlayerPauseMenu pauseMenu;
    
    public void UpdateCrosshair(Vector2 screenPosition, Sprite crosshairImg, float chargeAmount)
    {
        crosshair.ManualUpdate(screenPosition, crosshairImg, chargeAmount);
    }

    public void UpdatePlayerData(PlayerCharacter mainCharacter)
    {
        playerData.ManualUpdate(mainCharacter);
    }
    
    public void UpdateInteraction(AbstractInteractable interactionTarget, Vector2 interactionScreenPos)
    {
        if (!interactionTarget || interactionTarget.IsConcealed())
        {
            interaction.ManualUpdate();
            return;
        }
        
        string interactionText = interactionTarget.ReadInteraction();
        //TODO: also pass an bool to render with a different color when the interaction is not possible?
        interaction.ManualUpdate(interactionScreenPos, interactionText);
    }

    public void TogglePauseMenu(bool value)
    {
        pauseMenu.gameObject.SetActive(value);
    }
}
