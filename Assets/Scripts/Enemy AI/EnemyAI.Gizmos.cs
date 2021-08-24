using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    private void GizmosDecision()
    {
        Vector3 myPos = character.GetTargetablePosition();

        Color stateColor = GizmosColors.decisionStateNormal;
        bool drawSearchArea = false;

        if (decisionState == AIState.SEARCH)
        {
            stateColor = GizmosColors.decisionStateSearch;
            drawSearchArea = true;
        }
        else if (decisionState == AIState.ENGAGE)
        {
            stateColor = GizmosColors.decisionStateEngage;
        }

        Gizmos.color = stateColor;
        Gizmos.DrawLine(myPos, decisionPos);
        if (decisionTarget)
        {
            Vector3 cubePos = decisionTarget.GetTargetablePosition();
            Vector3 cubeSize = Vector3.one;
            Gizmos.DrawWireCube(cubePos, cubeSize);
        }
        if (drawSearchArea)
        {
            Gizmos.DrawWireSphere(decisionPos, searchAreaSize);
        }
    }

    private void GizmosDetection()
    {
        Vector3 myPos = transform.position;
        Vector3 myDir = transform.forward;
        float negativeSightRadius = 360 - sightRadius;

        Gizmos.color = GizmosColors.sightRange;
        GizmosExtensions.DrawWireArc(myPos, -myDir, negativeSightRadius, sightRange);

        Gizmos.color = GizmosColors.sightRadius;
        GizmosExtensions.DrawWireArc(myPos, myDir, sightRadius, sightRange);
    }
    
    private void GizmosNavigation()
    {
        if (!hasNavPath) return;

        Vector3 myPos = transform.position;

        Gizmos.color = GizmosColors.navigationPath;
        Vector3[] corners = navigationPath.corners;
        Vector3 fromPos = myPos;
        Vector3 toPos;
        for (int index = 1; index < corners.Length; index++)
        {
            toPos = corners[index];
            Gizmos.DrawLine(fromPos, toPos);
            fromPos = toPos;
        }

        Vector3 cubeSize = Vector3.one * 0.1F;

        Gizmos.color = GizmosColors.navigationFirstPos;
        Gizmos.DrawLine(myPos, navigationFirstPos);
        Gizmos.DrawWireCube(navigationFirstPos, cubeSize);

        Gizmos.color = GizmosColors.navigationLastPos;
        Gizmos.DrawLine(myPos, navigationLastPos);
        Gizmos.DrawWireCube(navigationLastPos, cubeSize);

        Gizmos.color = GizmosColors.navigationDir;
        Vector3 positionWithNavDir = myPos + navigationDir;
        Vector3 positionWithForward = myPos + transform.forward;
        Gizmos.DrawLine(myPos, positionWithNavDir);
        Gizmos.DrawWireSphere(positionWithNavDir, 0.1F);
        Gizmos.DrawSphere(positionWithForward, 0.1F);
    }

    private void GizmosSelectedDetection()
    {
        Gizmos.color = GizmosColors.detectedCharacter;
        foreach (Character forChara in detectedCharacterList)
        {
            Vector3 position = forChara.GetTargetablePosition();
            Gizmos.DrawWireSphere(position, 0.5F);
        }
    }
}
