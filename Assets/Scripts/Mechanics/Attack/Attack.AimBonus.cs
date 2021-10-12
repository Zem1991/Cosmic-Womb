using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Attack : MonoBehaviour
{
    [Header("Aim Boost")]
    [SerializeField] private float aimMax;
    [SerializeField] private float aimRecovery;
    [SerializeField] private float aimCost;

    public bool HasAimBoost()
    {
        return aimMax > 0;
    }
    public float GetAimMax()
    {
        return aimMax;
    }
    public float GetAimRecovery()
    {
        return aimRecovery;
    }
    public float GetAimCost()
    {
        return aimCost;
    }
}
