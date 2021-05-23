using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private bool isDead = false;
    [SerializeField] private int maximumHealth;
    [SerializeField] private int currentHealth;

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaximumHealth()
    {
        return maximumHealth;
    }

    public bool LoseHealth(int amount)
    {
        if (amount < 0) amount = 0;
        currentHealth -= amount;
        //TODO: will use negative health to check for gibbing
        if (isDead) return true;

        isDead = CheckNoHealth();
        if (characterController) characterController.detectCollisions = !isDead;

        if (animator)
        {
            animator.SetBool("Is Dead", isDead);
            animator.SetTrigger("Hurt");
        }
        return isDead;
    }

    public bool CheckNoHealth()
    {
        return currentHealth <= 0;
    }

    public bool GainHealth(int amount)
    {
        if (amount < 0) amount = 0;
        currentHealth += amount;
        if (currentHealth > maximumHealth) currentHealth = maximumHealth;
        return CheckFullHealth();
    }

    public bool CheckFullHealth()
    {
        return currentHealth >= maximumHealth;
    }

    public void Die()
    {
        Debug.LogWarning("Die() was called for character " + characterName);
        LoseHealth(currentHealth);
    }
}
