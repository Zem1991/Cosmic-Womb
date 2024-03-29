using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteractable : AbstractInteractable
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Switch settings")]
    [SerializeField] private bool isOneTimeUse = false;
    [SerializeField] private bool isOn = false;

    public override bool CanInteract()
    {
        bool checkOneUse = !isOneTimeUse || (isOneTimeUse && !isOn);
        return checkOneUse;
    }

    public override bool Interact()
    {
        if (!CanInteract()) return false;
        base.Interact();

        isOn = !isOn;
        animator.SetBool("Is On", isOn);
        return true;
    }

    public override string ReadInteraction()
    {
        //TODO: "Use switch" is strange. I can put an string variable so the prefab can define what should be used instead.
        string result = "Use switch";
        if (isOneTimeUse && isOn)
        {
            result = "It's stuck";
        }
        return result;
    }
}
