using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Attack : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private float audioRange = 25F;

    public float GetAudioRange()
    {
        return audioRange;
    }
}
