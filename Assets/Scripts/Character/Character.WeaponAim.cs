using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Weapon Aim")]
    [SerializeField] private Vector3 aimPos;
    [SerializeField] private float aimDisplacement;
    [SerializeField] private float aimCurrent;

    private void UpdateWeaponAim()
    {
        Vector3 aimPosBefore = aimPos;
        aimDisplacement = Vector3.Distance(aimPosBefore, aimPos);
        aimCurrent -= aimDisplacement;

        float recovery = weapon.GetAimRecovery();
        float recoveryPerFrame = recovery * Time.deltaTime;
        aimCurrent += recoveryPerFrame;

        AimClamp();
    }

    private void AimClamp()
    {
        float aimMin = weapon.GetAimMin();
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
        this.aimPos = aimPos;
    }

    public float GetAimScale()
    {
        //float aimMin = weapon.GetAimMin();
        float aimMax = weapon.GetAimMax();
        if (aimMax <= 0) return 1;
        return aimCurrent / aimMax;
    }
}
