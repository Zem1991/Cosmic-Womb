using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretAreaLevelEvent : LevelEvent
{
    [Header("Secret Area settings")]
    [SerializeField] private bool secretFound;

    public override bool TriggerEvent()
    {
        base.TriggerEvent();

        //TODO: Make something to call ONLY ONCE the "Secret Found" message.
        secretFound = true;

        throw new System.NotImplementedException();
    }
}
