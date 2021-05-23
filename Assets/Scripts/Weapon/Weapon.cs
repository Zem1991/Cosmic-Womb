using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private Projectile projectile;

    [Header("Aiming")]
    [SerializeField] private float aimMin = 10;
    [SerializeField] private float aimMax = 10;
    [SerializeField] private float aimRecovery = 10;
    [SerializeField] private float aimDecreaseOnFire = 10;
    [SerializeField] private float aimDamageScale = 1;

    [Header("Firing")]
    [SerializeField] private float attackDelay = 0.4F;
    [SerializeField] private int attackShots = 1;
    [SerializeField] private float attackArc = 0;
    [SerializeField] private float burstDelay = 0.1F;
    [SerializeField] private int burstShots = 1;
    [SerializeField] private float effectiveRange = 15F;

    #region Projectile
    public Projectile GetProjectile()
    {
        return projectile;
    }
    #endregion

    #region Firing
    public float GetAimMin()
    {
        return aimMin;
    }
    public float GetAimMax()
    {
        return aimMax;
    }
    public float GetAimRecovery()
    {
        return aimRecovery;
    }
    public float GetAimDecreaseOnFire()
    {
        return aimDecreaseOnFire;
    }
    public float GetAimDamageScale()
    {
        return aimDamageScale;
    }
    #endregion

    #region Firing
    public float GetAttackDelay()
    {
        return attackDelay;
    }
    public int GetAttackShots()
    {
        return attackShots;
    }
    public float GetAttackArc()
    {
        return attackArc;
    }
    public float GetBurstDelay()
    {
        return burstDelay;
    }
    public int GetBurstShots()
    {
        return burstShots;
    }
    public float GetEffectiveRange()
    {
        return effectiveRange;
    }
    #endregion

    //private bool IsBurstFire()
    //{
    //    return burstShots > 1;
    //}

    //public float GetAttacksPerSecond()
    //{
    //    //attackDelay = 1 / shotsPerSecond;
    //    return 1 / attackDelay;
    //}
}
