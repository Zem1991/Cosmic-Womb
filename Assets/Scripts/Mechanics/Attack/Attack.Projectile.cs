using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Attack : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private Projectile projectile;
    [SerializeField] private int shots;

    public Projectile GetProjectile()
    {
        return projectile;
    }

    public int GetShots()
    {
        return shots;
    }
}
