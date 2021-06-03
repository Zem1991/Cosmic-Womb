using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Self References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;

    [Header("Identification")]
    [SerializeField] protected string characterName = "Unknown Character";
    [SerializeField] protected Allegiance allegiance = Allegiance.ENEMY;

    private void OnDrawGizmos()
    {
        Vector3 projSpawn = GetProjectileSpawnPoint();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(projSpawn, 0.5F);
    }

    private void FixedUpdate()
    {
        UpdateWeaponFire();
    }

    private void Update()
    {
        UpdateRotation();
        UpdateCombat();

        UpdateWeaponAim();
        //UpdateWeaponFire();

        UpdateCanvas();
    }

    #region Identification
    public string GetCharacterName()
    {
        return characterName;
    }
    public Allegiance GetAllegiance()
    {
        return allegiance;
    }
    #endregion
}
