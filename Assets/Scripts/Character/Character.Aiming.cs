using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    //This one will always show in the Inspector the same value 'aimPos' has.
    private Vector3 aimPosPrevious;

    [Header("Aiming")]
    [SerializeField] private Vector3 aimPos;
    [SerializeField] private float aimDisplacement;
    [SerializeField] private float aimCurrent;

    private void UpdateAiming()
    {
        aimDisplacement = Vector3.Distance(aimPosPrevious, aimPos);
        aimCurrent -= aimDisplacement;

        float recovery = weapon.GetAimRecovery();
        float recoveryPerFrame = recovery * Time.deltaTime;
        aimCurrent += recoveryPerFrame;

        AimClamp();
        aimPosPrevious = aimPos;
    }

    private void AimClamp()
    {
        float aimMin = 0F;
        float aimMax = weapon.GetAimMax();
        aimCurrent = Mathf.Clamp(aimCurrent, aimMin, aimMax);
    }

    private void DecreaseAim(float amount)
    {
        aimCurrent -= amount;
        AimClamp();
    }

    public void SetAimPos(Vector3 aimPos)
    {
        aimPosPrevious = this.aimPos;
        this.aimPos = aimPos;
    }

    public float GetAimBoost()
    {
        //float aimMin = weapon.GetAimMin();
        float aimMax = weapon.GetAimMax();
        if (aimMax <= 0) return 1;
        return aimCurrent / aimMax;
    }
}
