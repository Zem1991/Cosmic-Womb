using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Resource health;

    public int GetCurrentHealth()
    {
        return health.Maximum;
    }

    public int GetMaximumHealth()
    {
        return health.Maximum;
    }

    public bool CheckNoHealth()
    {
        return health.CheckEmpty();
    }
    
    public bool CheckFullHealth()
    {
        return health.CheckFull();
    }

    public bool LoseHealth(int amount)
    {
        if (amount <= 0) return false;
        health.Subtract(amount);

        //TODO: if already dead, will still use negative health to check for gibbing
        if (isDead) return false;

        isDead = CheckNoHealth();
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

    public bool GainHealth(int amount, bool isIncrease)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;

        if (isIncrease)
            return health.Increase(amount);
        else
            return health.Add(amount);
    }

    public bool GainHealthPercent(int percent)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        return health.AddPercent(percent);
    }
}
