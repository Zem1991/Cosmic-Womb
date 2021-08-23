using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Decision")]
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
        //if (DecideSearch()) return;
        DecideNormal();
    }

    private bool DecideEngage()
    {
        //TODO: This will make the AI go after the first enemy found until it's defeated.
        //I need something that tells the AI that wathever is closer should be selected.
        Character engageTarget = decisionTarget ? decisionTarget : reachableEnemy;
        //if (!CanEngage(engageTarget)) return false;

        if (decisionState != AIState.ENGAGE)
        {
            bool cannotBegin = !BeginEngage(engageTarget);
            if (cannotBegin) return false;
        }
        else
        {
            bool noTime = !EngageTimer();
            if (noTime)
            {
                EndEngage();
                return false;
            }
        }

        //TODO: clear variables used in other AIStates when returning true.
        EngageAction();
        return true;
    }

    private bool DecideSearch()
    {
        //Can only search something that was targeted first.
        if (!decisionTarget) return false;

        if (decisionState != AIState.SEARCH)
        {
            bool cannotBegin = !BeginSearch(decisionTarget);
            if (cannotBegin) return false;
        }
        else
        {
            bool noTime = !SearchTimer();
            if (noTime)
            {
                EndSearch();
                return false;
            }
        }

        //TODO: clear variables used in other AIStates when returning true.
        SearchAction();
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
