using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    //[Header("Gizmos")]
    //[SerializeField] private float stopDistance = 0.1F;
    //[SerializeField] private float attackDistance = 5F;

    private void GizmosDetection()
    {
        Vector3 myPos = transform.position;

        Gizmos.color = GizmoColors.detectionSightRange;
        Gizmos.DrawWireSphere(myPos, sightRange);

        float halfSightRadius = sightRadius / 2F;
        Vector3 fovMidPos = character.GetForwardDirection() * sightRange;
        Vector3 fovLeftPos = Quaternion.Euler(0, -halfSightRadius, 0) * fovMidPos;
        Vector3 fovRightPos = Quaternion.Euler(0, halfSightRadius, 0) * fovMidPos;

        Gizmos.color = GizmoColors.detectionSightArc;
        //Gizmos.DrawLine(myPos, myPos + fovMidPos);
        Gizmos.DrawLine(myPos, myPos + fovLeftPos);
        Gizmos.DrawLine(myPos, myPos + fovRightPos);

        if (decisionTarget)
        {
            Gizmos.color = GizmoColors.detectionTarget;
            Gizmos.DrawLine(myPos, decisionPos);
        }
    }

    private void GizmosNavigation()
    {
        Vector3 myPos = transform.position;
        Vector3 myRotDir = transform.forward;
        Vector3 myNavDir = navPathFirstDir;
        Vector3 myPosRotDir = myPos + myRotDir;
        Vector3 myPosNavDir = myPos + myNavDir;

        Gizmos.color = GizmoColors.movementDirection;
        Gizmos.DrawLine(myPos, myPosRotDir);
        Gizmos.DrawSphere(myPosRotDir, 0.1F);
        Gizmos.DrawWireSphere(myPosNavDir, 0.1F);

        if (hasNavPath)
        {
            Gizmos.color = GizmoColors.movementPath;
            Vector3 fromPos = myPos;
            Vector3 toPos = navPathFirstPos;
            //Gizmos.DrawLine(fromPos, toPos);

            Vector3[] corners = navPath.corners;
            for (int index = 0; index < corners.Length; index++)
            {
                toPos = corners[index];
                Gizmos.DrawLine(fromPos, toPos);
                fromPos = toPos;
            }
        }
    }
}
