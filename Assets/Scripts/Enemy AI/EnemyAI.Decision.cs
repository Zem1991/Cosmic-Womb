using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Decision: settings")]
    //[SerializeField] private float stopDistance = 0.1F;
    [SerializeField] private float attackDistance = 5F;

    [Header("Decision: current")]
    [SerializeField] AIState decisionState;
    [SerializeField] AIAction decisionAction;
    [SerializeField] private Vector3 decisionPos;
    [SerializeField] private Character decisionTarget;

    private bool HasDecisionAction()
    {
        return decisionAction != AIAction.NONE;
    }

    //TODO: what I was trying to achieve here could just be too much overthinking, and even if it worked it could introduce many bugs to further work on.
    //private bool CheckCurrentDecision()
    //{
    //    bool hasDetection = CheckDetection(decisionTarget);
    //    if (hasDetection)
    //    {
    //        ApplyReach(decisionTarget);
    //    }
    //    else
    //    {
    //        //TODO: CLEAR DECISION
    //    }

    //    //TODO: call CheckDetection and CheckReach on the current decisionTarget

    //    //TODO: this
    //    switch (currentState)
    //    {
    //        //case AIState.NORMAL:
    //        //    break;
    //        case AIState.ALERT:
    //            break;
    //        case AIState.SEARCH:
    //            break;
    //        case AIState.ENGAGE:
    //            return DecideEngage();
    //        //default:
    //        //    break;
    //    }
    //    return false;
    //}

    private void TakeNewDecision()
    {
        if (DecideEngage()) return;
        if (DecideSearch()) return;
        DecideNormal();

        //if (DecideAttackEnemy()) return;
        //if (DecideEngageEnemy()) return;
        //if (DecideSearchEnemy()) return;
        //if (DecideMoveTo()) return;
        //DecideNone();
    }

    private bool DecideEngage()
    {
        if (!reachableEnemy) return false;

        //TODO: I could make an EnemyAI.Engage class to deal exclusively with the many ways the controlled character can perform combat actions.
        //This can even help later when making more specific/smart enemies, when making derived classes.

        Vector3 targetablePosition = reachableEnemy.GetTargetablePosition();
        float distance = Vector3.Distance(transform.position, targetablePosition);
        float attackRange = character.GetWeapon().GetEffectiveRange();

        bool withinAttackRange = distance <= attackRange;
        bool withinAttackDistance = distance <= attackDistance;
        if (!withinAttackRange) return false;

        decisionState = AIState.ENGAGE;
        decisionAction = withinAttackDistance ? AIAction.ATTACK : AIAction.MOVE_AND_ATTACK;
        decisionPos = targetablePosition;
        decisionTarget = reachableEnemy;

        //TODO: clear variables used in other AIStates when returning true.
        return true;
    }

    private bool DecideSearch()
    {
        if (!decisionTarget) return false;

        if (decisionState == AIState.ENGAGE)
        {
            BeginSearch(decisionTarget);
        }
        else if (decisionState != AIState.SEARCH)
        {
            return false;
        }
        else
        {
            bool noSearchTime = !SearchTimer();
            if (noSearchTime)
            {
                EndSearch();
                return false;
            }
        }

        SearchAction();

        //TODO: clear variables used in other AIStates when returning true.
        return true;
    }

    private bool DecideNormal()
    {
        decisionState = AIState.NORMAL;
        decisionAction = AIAction.NONE;
        decisionPos = transform.position;
        decisionTarget = null;
        return true;
    }
}
