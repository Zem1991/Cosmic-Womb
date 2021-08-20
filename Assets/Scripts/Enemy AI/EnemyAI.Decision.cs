using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Decision: settings")]
    //[SerializeField] private float stopDistance = 0.1F;
    [SerializeField] private float attackDistance = 5F;

    [Header("Decision: current")]
    [SerializeField] AIState currentState;
    [SerializeField] AIAction currentDecision;
    [SerializeField] private Vector3 decisionPos;
    [SerializeField] private Character decisionTarget;

    private bool HasDecision()
    {
        return currentDecision != AIAction.NONE;
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

        Vector3 targetablePosition = reachableEnemy.GetTargetablePosition();
        float distance = Vector3.Distance(transform.position, targetablePosition);
        float attackRange = character.GetWeapon().GetEffectiveRange();

        bool withinAttackRange = distance <= attackRange;
        bool withinAttackDistance = distance <= attackDistance;
        if (!withinAttackRange) return false;

        currentState = AIState.ENGAGE;
        currentDecision = withinAttackDistance ? AIAction.ATTACK : AIAction.MOVE_AND_ATTACK;
        decisionPos = targetablePosition;
        decisionTarget = reachableEnemy;
        return true;
    }

    private bool DecideNormal()
    {
        currentState = AIState.NORMAL;
        currentDecision = AIAction.NONE;
        decisionPos = transform.position;
        decisionTarget = null;
        return true;
    }

    //private bool DecideAttackEnemy()
    //{
    //    if (calcReachableEnemy)
    //    {
    //        float distance = Vector3.Distance(transform.position, calcReachableEnemyPos);
    //        float attackRange = character.GetWeapon().GetEffectiveRange();
    //        bool enemyWithinAttackRange = distance <= attackRange;
    //        if (enemyWithinAttackRange)
    //        {
    //            currentDecision = AIAction.ATTACK_ENEMY;
    //            currentDecisionPos = calcReachableEnemyPos;
    //            currentDecisionTarget = calcReachableEnemy;
    //            //currentDecisionStoppingDistance = 1.25F;
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //private bool DecideEngageEnemy()
    //{
    //    if (calcReachableEnemy)
    //    {
    //        currentDecision = AIAction.ENGAGE_ENEMY;
    //        currentDecisionPos = calcReachableEnemyPos;
    //        currentDecisionTarget = calcReachableEnemy;
    //        //currentDecisionStoppingDistance = 1.25F;
    //        return true;
    //    }
    //    return false;
    //}

    //private bool DecideSearchEnemy()
    //{
    //    bool knowsTheEnemyExists = currentDecisionTarget;
    //    if (!calcReachableEnemy && knowsTheEnemyExists)
    //    {
    //        currentDecision = AIAction.SEARCH_ENEMY;
    //        //currentDecisionPos = currentDecisionPos;
    //        //currentDecisionTarget = currentDecisionTarget;
    //        //currentDecisionStoppingDistance = 1.25F;
    //        return true;
    //    }
    //    return false;
    //}

    //private bool DecideMoveTo()
    //{
    //    return false;
    //}
}
