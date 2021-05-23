using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Decision: current")]
    [SerializeField] AIDecision currentDecision;
    [SerializeField] private Vector3 currentDecisionPos;
    [SerializeField] private Character currentDecisionTarget;
    [SerializeField] private float currentDecisionStoppingDistance = 0.1F;

    private void DecideDecision()
    {
        if (DecideAttackEnemy()) return;
        if (DecideEngageEnemy()) return;
        if (DecideSearchEnemy()) return;
        if (DecideMoveTo()) return;
        DecideNone();
    }

    private bool DecideAttackEnemy()
    {
        if (calcReachableEnemy)
        {
            float distance = Vector3.Distance(transform.position, calcReachableEnemyPos);
            float attackRange = character.GetWeapon().GetEffectiveRange();
            bool enemyWithinAttackRange = distance <= attackRange;
            if (enemyWithinAttackRange)
            {
                currentDecision = AIDecision.ATTACK_ENEMY;
                currentDecisionPos = calcReachableEnemyPos;
                currentDecisionTarget = calcReachableEnemy;
                //currentDecisionStoppingDistance = 1.25F;
                return true;
            }
        }
        return false;
    }

    private bool DecideEngageEnemy()
    {
        if (calcReachableEnemy)
        {
            currentDecision = AIDecision.ENGAGE_ENEMY;
            currentDecisionPos = calcReachableEnemyPos;
            currentDecisionTarget = calcReachableEnemy;
            //currentDecisionStoppingDistance = 1.25F;
            return true;
        }
        return false;
    }

    private bool DecideSearchEnemy()
    {
        bool knowsTheEnemyExists = currentDecisionTarget;
        if (!calcReachableEnemy && knowsTheEnemyExists)
        {
            currentDecision = AIDecision.SEARCH_ENEMY;
            //currentDecisionPos = currentDecisionPos;
            //currentDecisionTarget = currentDecisionTarget;
            //currentDecisionStoppingDistance = 1.25F;
            return true;
        }
        return false;
    }

    private bool DecideMoveTo()
    {
        return false;
    }

    private bool DecideNone()
    {
        currentDecision = AIDecision.NONE;
        currentDecisionPos = transform.position;
        currentDecisionTarget = null;
        //currentDecisionStoppingDistance = 0.1F;
        return true;
    }
}
