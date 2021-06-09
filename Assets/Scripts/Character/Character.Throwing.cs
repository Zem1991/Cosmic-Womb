using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Throwing")]
    [SerializeField] private float throwMax;
    [SerializeField] private float throwIncrease;
    [SerializeField] private float throwCurrent;
    [SerializeField] private bool isPreparingThrow;

    private void UpdateThrowing()
    {
        if (!grenade) return;
        if (!isPreparingThrow) return;

        if (throwCurrent >= throwMax)
        {
            ThrowGrenadeEnd();
        }
        else
        {
            float increasePerFrame = throwIncrease * Time.deltaTime;
            throwCurrent += increasePerFrame;
            burstDelayRemaining -= Time.fixedDeltaTime;
            ThrowClamp();
        }
    }

    #region Execution
    private void ThrowClamp()
    {
        float throwMin = 0F;
        float throwMax = this.throwMax;
        aimCurrent = Mathf.Clamp(throwCurrent, throwMin, throwMax);
    }
    private void ThrowGrenadeStart()
    {
        //This method only signals that something must be thrown.
        //The UpdateThrowing() does all the throw charge logic and most other stuff.
        isPreparingThrow = true;
    }
    private void ThrowGrenadeEnd()
    {
        Vector3 position = GetProjectileSpawnPoint();
        Quaternion shooterRot = transform.rotation;

        Projectile newProjectile = Instantiate(grenade, position, shooterRot);
        newProjectile.Initialize(this, null);
        newProjectile.ApplyForce(transform.forward, throwCurrent * 1000);

        throwCurrent = 0;
        isPreparingThrow = false;
    }
    #endregion

    #region Variables
    public float GetThrowMax()
    {
        return throwMax;
    }
    public float GetThrowIncrease()
    {
        return throwIncrease;
    }
    public float GetThrowCurrent()
    {
        return throwCurrent;
    }
    public bool IsPreparingThrow()
    {
        return isPreparingThrow;
    }
    #endregion
}
