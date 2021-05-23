using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private GameObject interactableObj;

    public void Interact(IInteractable interactable)
    {
        throw new NotImplementedException();
    }

    public void InteractContinuous(IInteractable interactable)
    {
        throw new NotImplementedException();
    }
}
