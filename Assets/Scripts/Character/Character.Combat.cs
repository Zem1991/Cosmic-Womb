using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Combat")]
    [SerializeField] private Vector3 projectileSpawnOffset;
    [SerializeField] private Vector3 targetablePosition;
    [SerializeField] private Vector3 projectileSpawnPoint;
    [SerializeField] protected Weapon weapon;

    private void UpdateCombat()
    {
        Vector3 myPos = transform.position;

        Quaternion forwardRot = Quaternion.LookRotation(transform.forward);
        Vector3 spawnOffset = forwardRot * projectileSpawnOffset;

        targetablePosition = myPos;
        targetablePosition.y += 1.5F;

        projectileSpawnPoint = myPos + spawnOffset;
    }

    #region Variables
    public Vector3 GetTargetablePosition()
    {
        return targetablePosition;
    }
    public Vector3 GetProjectileSpawnPoint()
    {
        return projectileSpawnPoint;
    }
    #endregion

    #region Weapon and Grenade
    public Weapon GetWeapon()
    {
        return weapon;
    }
    public bool CanUseWeapon()
    {
        return weapon && attackDelayRemaining <= 0 && burstDelayRemaining <= 0 && burstShotsRemaining <= 0;
    }
    public bool UseWeapon()
    {
        if (!CanUseWeapon()) return false;
        burstShotsRemaining = weapon.GetBurstShots();
        Shoot();
        return true;
    }
    public void UseGrenade()
    {
        throw new NotImplementedException();
    }
    #endregion
}
