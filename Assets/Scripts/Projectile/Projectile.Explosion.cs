using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Explosion")]
    [SerializeField] private Explosion explosionPrefab;
    [SerializeField] private float explosionRadius = 5;
    [SerializeField] private float explosionGrowth = 10;
    [SerializeField] private float explosionDamage = 50;

    private bool CanExplode()
    {
        return explosionPrefab;
    }

    private void Explode()
    {
        if (!CanExplode())
        {
            Debug.LogWarning("Cannot explode without a explosionPrefab");
            return;
        }

        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Explosion newExplosion = Instantiate(explosionPrefab, pos, rot);
        newExplosion.Initialize(shooter, weapon, explosionRadius, explosionGrowth, explosionDamage);

        Destroy(gameObject);
    }
}
