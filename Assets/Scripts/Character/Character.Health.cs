using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private bool isDead = false;
    [SerializeField] private int maximumHealth;
    [SerializeField] private int currentHealth;
    
    public int GetMaximumHealth()
    {
        return maximumHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool CheckNoHealth()
    {
        return currentHealth <= 0;
    }
    
    public bool CheckFullHealth()
    {
        return currentHealth >= maximumHealth;
    }

    public void LoseAllHealth()
    {
        Debug.LogWarning("LoseAllHealth() was called for character " + characterName);
        LoseHealth(currentHealth);
    }

    public bool LoseHealth(int amount)
    {
        if (amount <= 0) return false;
        currentHealth -= amount;
        
        //TODO: if already dead, will still use negative health to check for gibbing
        if (isDead) return false;

        isDead = CheckNoHealth();
        if (isDead)
        {
            Death();
        }
        if (animator)
        {
            animator.SetBool("Is Dead", isDead);
            animator.SetTrigger("Hurt");
        }
        return isDead;
    }

    public bool GainHealth(int amount)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        if (amount <= 0) return false;

        currentHealth += amount;
        if (currentHealth > maximumHealth) currentHealth = maximumHealth;
        return true;
    }
    
    protected virtual void Death()
    {
        //characterController.detectCollisions = false;
        Destroy(gameObject);
    }
}
