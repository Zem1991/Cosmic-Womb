using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelEvent : AbstractLevelEvent
{
    //[Header("End settings")]
    //[SerializeField] private LevelController levelController;

    public override bool TriggerEvent()
    {
        base.TriggerEvent();
        LevelController.Instance.EndLevel();
        return true;
    }
}
