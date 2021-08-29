using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlockerLevelEvent : AbstractLevelEvent
{
    [Header("Door Unlocker settings")]
    [SerializeField] private List<DoorInteractable> doorList = new List<DoorInteractable>();
    [SerializeField] private bool alsoInteract;

    public override bool TriggerEvent()
    {
        base.TriggerEvent();

        foreach (DoorInteractable forDoor in doorList)
        {
            forDoor.Unlock();
            if (alsoInteract) forDoor.Interact();
        }

        return true;
    }
}
