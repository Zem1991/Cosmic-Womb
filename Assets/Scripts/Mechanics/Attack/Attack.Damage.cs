using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Attack : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damageMin = 6;
    [SerializeField] private int damageMax = 10;
    [SerializeField] private float attackDelay = 0.4F;

    public int GetDamageMin()
    {
        return damageMin;
    }

    public int GetDamageMax()
    {
        return damageMax;
    }

    public float GetAttackDelay()
    {
        return attackDelay;
    }
}
