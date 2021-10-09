using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    [Header("Firing")]
    [SerializeField] private float attackDelayRemaining;
    [SerializeField] private float burstDelayRemaining;
    [SerializeField] private int burstShotsRemaining;

    private void UpdateFiring()
    {
        if (CanUseWeapon()) return;
        UpdateBurst();
        UpdateAttack();
    }
    
    private void FireWeapon()
    {
        Vector3 position = GetProjectileSpawnPoint();
        Quaternion shooterRot = transform.rotation;

        int shots = Mathf.Max(1, weapon.GetAttackShots());
        float arc = Mathf.Max(0, weapon.GetAttackArc());
        float arcStart = arc / -2F;
        float spreadArc = shots <= 1 ? 0 : arc / (shots - 1);

        for (int i = 0; i < shots; i++)
        {
            float shotAngle = arcStart + (spreadArc * i);
            Vector3 shotRotEuler = shooterRot.eulerAngles;
            shotRotEuler.y += shotAngle;
            Quaternion shotRot = Quaternion.Euler(shotRotEuler);

            Projectile newProjectile = Instantiate(weapon.GetProjectile(), position, shotRot);
            newProjectile.Initialize(this, weapon);

            //TODO: And what should I do in the case where I want gizmos showing the audible area? Cry?
            SoundPropagator.Propagate(position, weapon.GetShotAudibleRange());
        }

        float aimDecrease = weapon.GetAimDecreaseOnFire();
        DecreaseAim(aimDecrease);
        
        attackDelayRemaining = weapon.GetAttackDelay();
        burstDelayRemaining = weapon.GetBurstDelay();
        burstShotsRemaining--;
    }

    private void UpdateBurst()
    {
        if (burstDelayRemaining > 0)
        {
            burstDelayRemaining -= Time.fixedDeltaTime;
        }
        else if (burstShotsRemaining > 0)
        {
            FireWeapon();
        }
    }

    private void UpdateAttack()
    {
        if (burstShotsRemaining > 0)
        {
            return;
        }
        if (attackDelayRemaining > 0)
        {
            attackDelayRemaining -= Time.fixedDeltaTime;
        }
    }
}
