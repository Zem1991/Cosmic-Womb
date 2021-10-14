using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class AbstractCharacter : MonoBehaviour
{
    [Header("Aim Bonus")]
    [SerializeField] private float aimDisplacement;
    [SerializeField] private float aimCurrent;
    [SerializeField] private float aimMax;

    private void UpdateAimBonus()
    {
        aimDisplacement = Vector3.Distance(rotPosPrevious, rotPos);
        aimCurrent -= aimDisplacement;
        aimMax = attack.GetAimMax();

        float recovery = attack.GetAimRecovery();
        float recoveryPerFrame = recovery * Time.deltaTime;
        aimCurrent += recoveryPerFrame;

        AimClamp();
    }

    private void AimClamp()
    {
        //float aimMin = 0F;
        //float aimMax = aimMaximum;
        aimCurrent = Mathf.Clamp(aimCurrent, 0F, aimMax);
    }

    private void DecreaseAim(float amount)
    {
        aimCurrent -= amount;
        AimClamp();
    }

    public float GetAimBonus()
    {
        //float aimMin = weapon.GetAimMin();
        //float aimMax = weapon.GetAimMax();
        if (aimMax <= 0) return 1;
        return aimCurrent / aimMax;
    }
}
