using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class AbstractCharacter : MonoBehaviour
{
    [Header("Combat - Settings")]
    [SerializeField] private Vector3 projectileSpawnOffset;

    [Header("Combat - Variables")]
    [SerializeField] private Vector3 projectileSpawnPoint;
    [SerializeField] private Vector3 targetablePosition;

    private void UpdateCombat()
    {
        Vector3 myPos = transform.position;
        Quaternion forwardRot = Quaternion.LookRotation(transform.forward);
        Vector3 spawnOffset = forwardRot * projectileSpawnOffset;

        projectileSpawnPoint = myPos + spawnOffset;

        targetablePosition = myPos;
        targetablePosition.y += 1.5F;   //TODO: universal height variable?
    }

    #region Settings
    public Vector3 GetProjectileSpawnOffset()
    {
        return projectileSpawnOffset;
    }
    #endregion

    #region Variables
    public Vector3 GetProjectileSpawnPoint()
    {
        return projectileSpawnPoint;
    }
    public Vector3 GetTargetablePosition()
    {
        return targetablePosition;
    }
    #endregion
}
