using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour
{
    [Header("AbstractInteractable settings")]
    [SerializeField] protected bool isConcealed = false;

    [Header("Level Effects")]
    [SerializeField] private List<AbstractLevelEvent> firstTriggerEffectList = new List<AbstractLevelEvent>();
    [SerializeField] private List<AbstractLevelEvent> alwaysTriggerEffectList = new List<AbstractLevelEvent>();
    [SerializeField] private bool firstEffectsTriggered;
    
    public bool IsConcealed()
    {
        return isConcealed;
    }

    protected void TriggerLevelEvents()
    {
        if (!firstEffectsTriggered)
        {
            TriggerLevelEvents(firstTriggerEffectList);
            firstEffectsTriggered = true;
        }
        TriggerLevelEvents(alwaysTriggerEffectList);
    }

    private void TriggerLevelEvents(List<AbstractLevelEvent> list)
    {
        foreach (AbstractLevelEvent forALE in list)
        {
            forALE.TriggerEvent();
        }
    }

    public abstract bool CanInteract();
    public virtual bool Interact()
    {
        //After the first successful interaction, regardless of who or what did it, any concealment is broken.
        isConcealed = false;
        TriggerLevelEvents();
        return true;
    }
    public abstract string ReadInteraction();
}
