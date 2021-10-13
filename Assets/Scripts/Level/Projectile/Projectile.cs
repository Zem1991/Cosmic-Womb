using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    //[Header("Auto references")]
    private Collider _collider;
    private Rigidbody _rigidbody;

    [Header("Initialization")]
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private AbstractCharacter shooter;
    [SerializeField] private Attack attack;

    //private virtual void OnDrawGizmos()
    //{
    //    if (HasGuidance())
    //    {
    //        Vector3 position = homingTarget.GetTargetablePosition();
    //        Gizmos.color = GizmoColors.projectileTarget;
    //        Gizmos.DrawLine(transform.position, position);
    //    }
    //}

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //_collider = GetComponent<Collider>();
        //_rigidbody = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(_collider, shooter.GetComponent<Collider>());
    }

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
            distanceMax = attack.GetRange();
        }
    }

    protected virtual void Update()
    {
        //UpdateGuidance();
        UpdateLifespan();
    }

    private void FixedUpdate()
    {
        ActualMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Impact(collision.gameObject);
        Expire();
    }
}
