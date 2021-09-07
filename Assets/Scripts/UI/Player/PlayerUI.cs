using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : SceneUI
{
    [Header("Panels")]
    [SerializeField] private UICrosshair crosshair;
    [SerializeField] private UIPanel_PlayerData playerData;
    [SerializeField] private UIInteraction interaction;

    public void UpdateCrosshair(Vector2 screenPosition, Sprite crosshairImg, float chargeAmount)
    {
        crosshair.ManualUpdate(screenPosition, crosshairImg, chargeAmount);
    }

    public void UpdatePlayerData(MainCharacter mainCharacter)
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
}
