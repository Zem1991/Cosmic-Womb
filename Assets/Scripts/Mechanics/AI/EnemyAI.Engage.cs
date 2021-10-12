using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Engage: settings")]
    [SerializeField] private float engageStateTimeMax = 10F;
    [SerializeField] private float engageDistance = 5F;

    [Header("Engage: current")]
    [SerializeField] private float engageStateTimeCurrent;
    //[SerializeField] private float engageActionTimeCurrent;

    private bool CanEngage(AbstractCharacter target)
    {
        if (!target) return false;

        bool detected = CheckDetection(target);
        if (detected)
        {
            ReachTarget(target);
        }
        return detected;
    }

    private bool BeginEngage(AbstractCharacter target)
    {
        if (!CanEngage(target)) return false;

        Vector3 targetPos = target.GetTargetablePosition();
        targetPos = NavigationSnapPosition(targetPos);

        decisionState = AIState.ENGAGE;
        decisionAction = AIAction.MOVE_AND_ROTATE;
        decisionPos = targetPos;
        decisionTarget = target;

        engageStateTimeCurrent = engageStateTimeMax;
        //engageActionTimeCurrent = 0;
        return true;
    }

    private bool EngageTimer()
    {
        if (CanEngage(decisionTarget))
            engageStateTimeCurrent = engageStateTimeMax;
        else
            engageStateTimeCurrent -= Time.deltaTime;
        //engageActionTimeCurrent -= Time.deltaTime;
        return engageStateTimeCurrent > 0;
    }

    private void EndEngage()
    {
        engageStateTimeCurrent = 0;
        //engageActionTimeCurrent = 0;
    }

    private void EngageAction()
    {
        Vector3 myPos = transform.position;
        Vector3 targetablePosition = decisionTarget.GetTargetablePosition();

        float distance = Vector3.Distance(myPos, targetablePosition);
        float attackRange = character.GetAttack().GetRange();

        bool withinAttackRange = distance <= attackRange;
        bool withinAttackDistance = distance <= engageDistance;

        //TODO: needs an extra check for if the decisionTarget is still being seen. This would fix:
        // -    Trying to shoot through walls/obstacles.
        // -    Trying to shoot through other characters.
        if (!withinAttackRange)
        {
            bool doorSituation = CanOpenDoor();
            if (doorSituation) decisionAction = AIAction.INTERACT;
            else decisionAction = AIAction.MOVE_AND_ROTATE;
        }
        else
        {
            decisionAction = withinAttackDistance ? AIAction.ATTACK : AIAction.MOVE_AND_ATTACK;
        }

        decisionPos = targetablePosition;
    }
}
