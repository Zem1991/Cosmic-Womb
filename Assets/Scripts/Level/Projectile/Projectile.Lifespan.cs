using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Lifespan")]
    [SerializeField] private float durationMax = 1F;
    [SerializeField] private float durationCurrent;
    [SerializeField] private float distanceMax = 15F;
    [SerializeField] private float distanceCurrent;

    private void UpdateLifespan()
    {
        durationCurrent += Time.deltaTime;
        if (durationCurrent > durationMax)
        {
            Expire();
        }

        distanceCurrent = Vector3.Distance(spawnPosition, transform.position);
        if (0 < distanceMax && distanceMax < distanceCurrent)
        {
            Expire();
        }
    }

    private void Expire()
    {
        Explode();
        Destroy(gameObject);
    }
}
