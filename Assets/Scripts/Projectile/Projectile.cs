using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Runtime")]
    [SerializeField] private Character shooter;
    [SerializeField] private Weapon weapon;

    public void Initialize(Character shooter, Weapon weapon)
    {
        this.shooter = shooter;
        this.weapon = weapon;
        spawnPosition = transform.position;

        bool hasBoost = weapon.HasChargeBoost() || weapon.HasAimBoost();
        float aimScale = hasBoost ? shooter.GetWeaponPower() : 1F;
        if (aimScale < 1)
        {
            aimScale *= 0.8F;
            aimScale += 0.2F;
        }
        transform.localScale = Vector3.one * aimScale;
        damage = Mathf.RoundToInt(damage * aimScale);
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
        UpdateDuration();
    }

    private void FixedUpdate()
    {
        ActualMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 point = contact.point;

        Character spanwerChar = shooter?.GetComponent<Character>();
        GameObject hitObj = collision.gameObject;
        Vector3 hitNormal = collision.contacts[0].normal;

        if (CheckDeflection(hitObj, hitNormal))
        {
            //hitNormal.y = 0;
            //hitNormal.Normalize();
            ////Debug.Log("hitNormal: " + hitNormal);

            //float angle = Mathf.Atan2(hitNormal.z, hitNormal.x);
            //angle *= Mathf.Rad2Deg;
            //angle = Helper.RoundToMultiple(angle, 45F);
            //Debug.Log("angle: " + angle);

            //Vector3 reflect = Vector3.Reflect(transform.forward, hitNormal);
            //transform.rotation = Quaternion.LookRotation(reflect);

            ////transform.Rotate(Vector3.up, angle);

            //Vector3 eulerMulitple = transform.eulerAngles;
            //eulerMulitple.y = Helper.RoundToMultiple(eulerMulitple.y, 45F);
            ////eulerMulitple.y = Helper.RoundToMultiple(eulerMulitple.y, 22.5F);
            //transform.eulerAngles = eulerMulitple;
            //return;
        }

        Character hitChar = hitObj.GetComponent<Character>();
        if (hitChar) hitChar.LoseHealth(damage);

        if (CanExplode())
        {
            Explode();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
