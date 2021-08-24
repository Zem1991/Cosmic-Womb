using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : AbstractInteractable
{
    [Header("Animator")]
    [SerializeField] private Animator animator;
    [SerializeField] private readonly string animatorBoolIsOpen = "IsOpen";

    //[Header("Door")]
    //[SerializeField] private float doorSpeed;
    //[SerializeField] private bool canOpen;
    //[SerializeField] private bool canClose;

    [Header("Occupants")]
    //TODO: I can switch the doorway trigger for using instead an Physics.CheckBox call.
    [SerializeField] private Collider doorway;
    [SerializeField] private HashSet<Character> doorwayOccupantList = new HashSet<Character>();

    private void OnTriggerEnter(Collider other)
    {
        Character chara = other.GetComponent<Character>();
        if (chara) doorwayOccupantList.Add(chara);
    }

    private void OnTriggerExit(Collider other)
    {
        Character chara = other.GetComponent<Character>();
        if (chara) doorwayOccupantList.Remove(chara);
    }

    public override bool CanInteract()
    {
        //TODO: Check settings for 'can open', 'can close', 'required keys', etc.
        return true;
    }

    public override bool Interact()
    {
        if (!CanInteract()) return false;
        if (IsOpen())
            Close();
        else
            Open();
        return true;
    }
    
    public bool IsOpen()
    {
        bool check = animator.GetBool(animatorBoolIsOpen);
        return check;
    }
    
    public bool IsDoorwayClear()
    {
        bool check = doorwayOccupantList.Count <= 0;
        return check;
    }

    public bool Open()
    {
        if (IsOpen()) return false;
        animator.SetBool(animatorBoolIsOpen, true);
        return true;
    }

    public bool Close()
    {
        if (!IsOpen()) return false;
        if (!IsDoorwayClear()) return false;
        animator.SetBool(animatorBoolIsOpen, false);
        return true;
    }
    
    public bool IsInTransition()
    {
        return animator.IsInTransition(0);
    }

    public bool CanCross()
    {
        return IsOpen() && !IsInTransition();
    }
}
