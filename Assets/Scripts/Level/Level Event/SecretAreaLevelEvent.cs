using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretAreaLevelEvent : AbstractLevelEvent
{
    [Header("Secret Area settings")]
    [SerializeField] private bool secretFound;
    
    public override bool TriggerEvent()
    {
        base.TriggerEvent();

        if (!secretFound)
        {
            LevelController.Instance.ReportSecretFound(this);

            Vector3 myPosition = transform.position;
            Debug.Log("SECRET FOUND - " + myPosition);
            secretFound = true;
        }

        return true;
    }
}
