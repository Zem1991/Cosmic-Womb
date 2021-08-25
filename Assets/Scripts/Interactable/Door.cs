using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : AbstractInteractable
{
    [Header("Animator")]
    [SerializeField] private Animator animator;
    [SerializeField] private readonly string animatorOpenThresholdName = "Open Threshold";
    [SerializeField] private float animatorOpenThresholdValue = 0F;

    [Header("Door")]
    [SerializeField] private bool isOpen = false;
    [SerializeField] private float doorSpeed = 1F;
    //[SerializeField] private bool canOpen;
    //[SerializeField] private bool canClose;

    [Header("Occupants")]
    //TODO: I can change having the doorway trigger by instead using an Physics.CheckBox call.
    [SerializeField] private Collider doorway;  //Useless?
    [SerializeField] private HashSet<Character> doorwayOccupantList = new HashSet<Character>();
    
    private void Awake()
    {
        if (IsOpen()) animatorOpenThresholdValue = 1F;
        animator.SetFloat(animatorOpenThresholdName, animatorOpenThresholdValue);
    }

    private void Update()
    {
        DoorMotion();
        animator.SetFloat(animatorOpenThresholdName, animatorOpenThresholdValue);
    }

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
            return Close();
        else
            return Open();
    }

    public override string ReadInteraction()
    {
        if (IsOpen())
            return "Close door";
        else
            return "Open door";
    }


    public bool IsOpen()
    {
        return isOpen;
    }
    
    public bool IsDoorwayClear()
    {
        return doorwayOccupantList.Count <= 0;
    }

    public bool Close()
    {
        //if (!IsOpen()) return false;
        if (!IsDoorwayClear()) return false;
        isOpen = false;
        return true;
    }

    public bool Open()
    {
        //if (IsOpen()) return false;
        isOpen = true;
        return true;
    }
    
    public bool IsIdle()
    {
        bool isClosed = animatorOpenThresholdValue <= 0;
        bool isOpen = animatorOpenThresholdValue >= 1;
        return isClosed || isOpen;
    }

    public bool CanCross()
    {
        return IsOpen() && IsIdle();
    }

    private void DoorMotion()
    {
        float change = Time.deltaTime * doorSpeed;
        if (isOpen)
        {
            animatorOpenThresholdValue += change;
            if (animatorOpenThresholdValue > 1F) animatorOpenThresholdValue = 1F;
        }
        else
        {
            animatorOpenThresholdValue -= change;
            if (animatorOpenThresholdValue < 0F) animatorOpenThresholdValue = 0F;
        }
    }
}
