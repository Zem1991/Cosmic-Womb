using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Impact")]
    [SerializeField] private int impactDamage;
    //[SerializeField] private bool damageOnImpact;
    [SerializeField] private bool destroyAfterImpact;

    private void Impact(GameObject hitObj)
    {
        AbstractCharacter hitChar = hitObj.GetComponent<AbstractCharacter>();
        if (hitChar) hitChar.TakeDamage(impactDamage);
    }

    private void PostImpact()
    {
        ImpactExplosion();
        if (destroyAfterImpact) Destroy(gameObject);
    }
}
