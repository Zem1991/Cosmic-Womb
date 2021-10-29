using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class AbstractCharacter : MonoBehaviour
{
    //[Header("Damage")]
    //TODO: stuff for damage resistances

    public virtual bool TakeDamage(int amount)
    {
        SubtractHealth(amount);
        bool noHealth = CheckNoHealth();

        //TODO: GIBBITUDE

        if (noHealth)
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
