using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Explosion")]
    [SerializeField] private Explosion explosionPrefab;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionGrowth;
    [SerializeField] private float explosionDamage;
    [SerializeField] private bool explodeOnImpact;
    [SerializeField] private bool explodeOnTimer;

    private bool CanExplode()
    {
        return explosionPrefab;
    }

    private bool ImpactExplosion()
    {
        if (!explodeOnImpact) return false;
        return Explode();
    }

    private bool TimerExplosion()
    {
        if (!explodeOnTimer) return false;
        return Explode();
    }

    private bool Explode()
    {
        if (!CanExplode()) return false;
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Explosion newExplosion = Instantiate(explosionPrefab, pos, rot);
        newExplosion.Initialize(shooter, attack, explosionRadius, explosionGrowth, explosionDamage);
        return true;
    }
}
