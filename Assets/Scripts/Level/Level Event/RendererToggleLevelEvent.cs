using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererToggleLevelEvent : LevelEvent
{
    [Header("Conceal Area settings")]
    [SerializeField] private bool toogleValue;

    public override bool TriggerEvent()
    {
        base.TriggerEvent();

        //TODO: get all renderers within some bounds, and set enabled = toogleValue;

        throw new System.NotImplementedException();
    }
}
