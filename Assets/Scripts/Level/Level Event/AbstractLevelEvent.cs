using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLevelEvent : MonoBehaviour
{
    [Header("Trigger settings")]
    [SerializeField] private bool triggerOnAwake;
    [SerializeField] private bool triggerOnStart;
    [SerializeField] private bool triggerOnEnter;
    [SerializeField] private bool triggerOnExit;
    [SerializeField] private bool triggerAfterDelay;

    //TODO: maybe I should move all timed-related triggering to another abstract class that is derived from this one?
    [Header("Timed settings")]
    [SerializeField] private float delayMaximum;
    [SerializeField] private float delayCurrent;

    [Header("Activation settings")]
    [SerializeField] private bool wasActivated;
    [SerializeField] private bool alwaysActivate;

    private void Awake()
    {
        if (CanActivate(triggerOnAwake)) TriggerEvent();
    }

    private void Start()
    {
        if (CanActivate(triggerOnStart)) TriggerEvent();
    }

    private void Update()
    {
        if (CanActivate(triggerAfterDelay))
        {
            if (delayCurrent >= delayMaximum)
                TriggerEvent();
            else
                delayCurrent += Time.deltaTime;
        }
    }

    //TODO: this may need overrides later
    private void OnTriggerEnter(Collider other)
    {
        //Should only test for Characters within bounds.
        AbstractCharacter otherCharacter = other.GetComponent<AbstractCharacter>();
        if (!otherCharacter) return;

        if (CanActivate(triggerOnEnter)) TriggerEvent();
    }

    //TODO: this may need overrides later
    private void OnTriggerExit(Collider other)
    {
        //Should only test for Characters within bounds.
        AbstractCharacter otherCharacter = other.GetComponent<AbstractCharacter>();
        if (!otherCharacter) return;

        if (CanActivate(triggerOnExit)) TriggerEvent();
    }

    //TODO: this may need overrides later
    public bool CanActivate(bool triggerValue)
    {
        bool canActivate = !wasActivated || (wasActivated && alwaysActivate);
        return triggerValue && canActivate;
    }

    //TODO: maybe I wanna set tis as protected, and have a base method for direct input interaction.
    public virtual bool TriggerEvent()
    {
        wasActivated = true;
        return true;
    }
}
