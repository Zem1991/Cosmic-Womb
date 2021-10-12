using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] protected Attack attack;
    [SerializeField] private float attackDelayRemaining;
    [SerializeField] private float repeatDelayRemaining;
    [SerializeField] private int repeatAmountRemaining;

    private void UpdateAttack()
    {
        if (CanAttack()) return;
        UpdateRepeatDelay();
        UpdateAttackDelay();
    }

    #region Usage
    public Attack GetAttack()
    {
        return attack;
    }
    public virtual bool CanAttack()
    {
        //MainCharacter depends on having ammo available. But the base Character doesn't need it.
        return attack && attackDelayRemaining <= 0 && repeatDelayRemaining <= 0 && repeatAmountRemaining <= 0;
    }
    public bool Attack()
    {
        if (!CanAttack()) return false;
        repeatAmountRemaining = attack.GetRepeatAmount();
        AttackInstance();
        return true;
    }
    private void AttackInstance()
    {
        Vector3 position = GetProjectileSpawnPoint();
        Quaternion shooterRot = transform.rotation;

        int shots = Mathf.Max(1, attack.GetShots());
        float arc = Mathf.Max(0, attack.GetArc());
        float arcStart = arc / -2F;
        float spreadArc = shots <= 1 ? 0 : arc / (shots - 1);

        for (int i = 0; i < shots; i++)
        {
            float shotAngle = arcStart + (spreadArc * i);
            Vector3 shotRotEuler = shooterRot.eulerAngles;
            shotRotEuler.y += shotAngle;
            Quaternion shotRot = Quaternion.Euler(shotRotEuler);

            Projectile newProjectile = Instantiate(attack.GetProjectile(), position, shotRot);
            newProjectile.Initialize(this, attack);

            //TODO: And what should I do in the case where I want gizmos showing the audible area? Cry?
            SoundPropagator.Propagate(position, attack.GetAudioRange());
        }

        float aimDecrease = attack.GetAimCost();
        DecreaseAim(aimDecrease);
        
        attackDelayRemaining = attack.GetAttackDelay();
        repeatDelayRemaining = attack.GetRepeatDelay();
        repeatAmountRemaining--;
    }
    #endregion

    #region Calculation
    public float GetAttackPower()
    {
        float charge = 0F;
        if (attack.HasAimBoost())
        {
            charge += GetAimBonus();
        }
        //if (attack.HasChargeBoost())
        //{
        //    //TODO: Nothing yet
        //}
        return charge;
    }
    #endregion

    #region Update
    private void UpdateRepeatDelay()
    {
        if (repeatDelayRemaining > 0)
        {
            repeatDelayRemaining -= Time.fixedDeltaTime;
        }
        else if (repeatAmountRemaining > 0)
        {
            AttackInstance();
        }
    }
    private void UpdateAttackDelay()
    {
        if (repeatAmountRemaining > 0)
        {
            return;
        }
        if (attackDelayRemaining > 0)
        {
            attackDelayRemaining -= Time.fixedDeltaTime;
        }
    }
    #endregion
}
