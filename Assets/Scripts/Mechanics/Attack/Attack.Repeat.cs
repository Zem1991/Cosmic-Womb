using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Attack : MonoBehaviour
{
    [Header("Repeat")]
    [SerializeField] private int repeatAmount;
    [SerializeField] private float repeatDelay;

    public int GetRepeatAmount()
    {
        return repeatAmount;
    }

    public float GetRepeatDelay()
    {
        return repeatDelay;
    }
}
