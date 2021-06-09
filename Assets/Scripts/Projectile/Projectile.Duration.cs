using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Duration (and Distance)")]
    [SerializeField] private float durationMax;
    [SerializeField] private float durationCurrent;
    [SerializeField] private float distanceCurrent;

    private void UpdateDurationAndDistance()
    {
        durationCurrent += Time.deltaTime;
        if (durationCurrent > durationMax)
        {
            TimerExplosion();
            Destroy(gameObject);
        }

        //TODO: only use timed durations instead of time and distance?
        distanceCurrent = Vector3.Distance(spawnPosition, transform.position);
        float maxDistance = weapon ? weapon.GetEffectiveRange() : 0;
        if (maxDistance > 0 && distanceCurrent > maxDistance)
        {
            TimerExplosion();
            Destroy(gameObject);
        }
    }
}
