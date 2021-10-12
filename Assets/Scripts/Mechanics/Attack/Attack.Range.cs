using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Attack : MonoBehaviour
{
    [Header("Range")]
    [SerializeField] private float range = 15F;
    [SerializeField] private float arc;

    public float GetRange()
    {
        return range;
    }

    public float GetArc()
    {
        return arc;
    }
}
