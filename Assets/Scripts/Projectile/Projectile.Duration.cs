using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Duration")]
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float travelDistance;
    [SerializeField] private float durationCurrent;

    private void UpdateDuration()
    {
        travelDistance = Vector3.Distance(spawnPosition, transform.position);
        durationCurrent += Time.deltaTime;

        float maxDistance = weapon.GetEffectiveRange();
        if (travelDistance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
