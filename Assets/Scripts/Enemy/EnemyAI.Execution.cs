using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    private void ExecuteDecision()
    {
        switch (currentDecision)
        {
            case AIDecision.NONE:
                break;
            case AIDecision.MOVE_TO:
                break;
            case AIDecision.SEARCH_ENEMY:
                break;
            case AIDecision.ENGAGE_ENEMY:
                break;
            case AIDecision.ATTACK_ENEMY:
                character.UseWeaponHold();
                break;
            default:
                break;
        }

        NavMove(currentDecisionPos);

        //bool hasDecisionTarget = DetPerform();
        //if (hasDecisionTarget)
        //{
        //    Character decisionTarget = detectedCharacter;
        //    bool hasNavigation = NavCan(decisionTarget.transform.position, out UnityEngine.AI.NavMeshHit nmHit);
        //    if (hasNavigation) decisionMovePos = nmHit.position;
        //}

        //NavMove(decisionMovePos);
    }
}
