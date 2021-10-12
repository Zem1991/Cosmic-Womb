using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Initialization")]
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private AbstractCharacter shooter;
    [SerializeField] private Attack attack;

    public void Initialize(AbstractCharacter shooter, Attack attack)
    {
        spawnPosition = transform.position;
        this.shooter = shooter;
        this.attack = attack;

        if (attack)
        {
            //TODO: charged projectiles
            //bool hasBoost = attack.HasChargeBoost() || attack.HasAimBoost();
            bool hasBoost = attack.HasAimBoost();
            float aimScale = hasBoost ? shooter.GetAttackPower() : 1F;
            if (aimScale < 1)
            {
                aimScale *= 0.8F;
                aimScale += 0.2F;
            }
            transform.localScale = Vector3.one * aimScale;
            impactDamage = Mathf.RoundToInt(impactDamage * aimScale);
        }
    }

    //private virtual void OnDrawGizmos()
    //{
    //    if (HasGuidance())
    //    {
    //        Vector3 position = homingTarget.GetTargetablePosition();
    //        Gizmos.color = GizmoColors.projectileTarget;
    //        Gizmos.DrawLine(transform.position, position);
    //    }
    //}

    private void Start()
    {
        //_collider = GetComponent<Collider>();
        //_rigidbody = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(_collider, shooter.GetComponent<Collider>());
    }

    protected virtual void Update()
    {
        UpdateGuidance();
        UpdateDurationAndDistance();
    }

    private void FixedUpdate()
    {
        ActualMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObj = collision.gameObject;
        Impact(hitObj);
        PostImpact();
    }
}
