using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    //[Header("Damage")]
    //TODO: stuff for damage resistances

    public virtual bool TakeDamage(int amount)
    {
        SubtractHealth(amount);
        isDead = CheckNoHealth();

        //TODO: GIBBITUDE
        ////TODO: if already dead, will still use negative health to check for gibbing
        //if (isDead) return false;

        if (isDead)
        {
            Die();
        }
        if (animator)
        {
            animator.SetBool("Is Dead", isDead);
            animator.SetTrigger("Hurt");
        }

        return isDead;
    }
}
