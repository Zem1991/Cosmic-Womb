using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelEvent : MonoBehaviour
{
    [Header("Trigger settings")]
    [SerializeField] private bool triggerOnAwake;
    [SerializeField] private bool triggerOnStart;
    [SerializeField] private bool triggerAfterDelay;
    [SerializeField] private bool triggerOnEnter;
    [SerializeField] private bool triggerOnExit;

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
        if (CanActivate(triggerOnEnter)) TriggerEvent();
    }

    //TODO: this may need overrides later
    private void OnCollisionExit(Collision collision)
    {
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