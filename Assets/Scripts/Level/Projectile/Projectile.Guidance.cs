using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Guidance")]
    [SerializeField] private float guidanceSpeed;
    //[SerializeField] protected ITargetable homingTarget;
    //[SerializeField] protected GameObject homingTargetObj;

    private bool CheckValidHomingTarget(GameObject obj)
    {
        //ITargetable targetable = obj?.GetComponent<ITargetable>();
        //if (targetable == null) return false;

        bool isCharacter = false;
        AbstractCharacter spanwerChar = shooter.GetComponent<AbstractCharacter>();
        if (spanwerChar)
        {
            AbstractCharacter targetChar = obj.GetComponent<AbstractCharacter>();
            bool charaIsNotOwner = targetChar != shooter;
            bool charaIsOpponent = true;// spanwerChar.CheckOpponent(targetChar);
            isCharacter = targetChar && charaIsNotOwner && charaIsOpponent;
        }

        //ITelekinesisTarget tkTarget = obj.GetComponent<ITelekinesisTarget>();
        //TelekinesisEffect tkEffect = effect as TelekinesisEffect;
        //bool isTkTarget = tkTarget != null && tkEffect;

        return isCharacter;// || isTkTarget;
    }

    private bool HasGuidance()
    {
        return guidanceSpeed > 0;// && homingTarget != null;
    }

    private void UpdateGuidance()
    {
        if (HasGuidance())
        {
            //Vector3 targetPos = homingTarget.GetTargetablePosition();
            ////Vector3 targetPos = this.homingTarget.transform.position;
            //float step = homingSpeed * Time.deltaTime;

            ////Character homingTarget = this.homingTarget.GetComponent<Character>();
            ////if (homingTarget) targetPos += homingTarget.GetTargetablePosition();

            //Vector3 direction = targetPos - transform.position;
            //Vector3 rotation = Vector3.RotateTowards(transform.forward, direction, step, 0F);
            //transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}
