using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class AbstractCharacter : MonoBehaviour
{
    [Header("Death")]
    [SerializeField] protected bool canRevive;
    [SerializeField] protected bool isDead;
    [SerializeField] protected int deathCount;

    protected virtual void Die()
    {
        isDead = true;
        deathCount++;

        //TODO: add animations and body, and then remove the Destroy() call.
        animator.SetBool("Is Dead", true);
        Destroy(gameObject);
    }
}
