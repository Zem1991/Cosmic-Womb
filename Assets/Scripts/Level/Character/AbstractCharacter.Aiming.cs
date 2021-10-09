using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    [Header("Aiming")]
    [SerializeField] private float aimDisplacement;
    [SerializeField] private float aimCurrent;
    [SerializeField] private float aimMaximum;

    private void UpdateAiming()
    {
        aimDisplacement = Vector3.Distance(rotPosPrevious, rotPos);
        aimCurrent -= aimDisplacement;
        aimMaximum = weapon.GetAimMax();

        float recovery = weapon.GetAimRecovery();
        float recoveryPerFrame = recovery * Time.deltaTime;
        aimCurrent += recoveryPerFrame;

        AimClamp();
    }

    private void AimClamp()
    {
        //float aimMin = 0F;
        //float aimMax = aimMaximum;
        aimCurrent = Mathf.Clamp(aimCurrent, 0F, aimMaximum);
    }

    private void DecreaseAim(float amount)
    {
        aimCurrent -= amount;
        AimClamp();
    }

    public float GetAimBoost()
    {
        //float aimMin = weapon.GetAimMin();
        //float aimMax = weapon.GetAimMax();
        if (aimMaximum <= 0) return 1;
        return aimCurrent / aimMaximum;
    }
}
