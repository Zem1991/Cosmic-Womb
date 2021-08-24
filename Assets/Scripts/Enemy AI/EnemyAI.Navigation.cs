using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Navigation: settings")]
    [SerializeField] private float stopDistance = 0.1F;
    [SerializeField] private int navAreas = NavMesh.AllAreas;

    [Header("Navigation: current")]
    [SerializeField] private bool hasNavPath;
    [SerializeField] private NavMeshPath navigationPath;
    [SerializeField] private Vector3 navigationFirstPos;
    [SerializeField] private Vector3 navigationLastPos;
    [SerializeField] private Vector3 navigationDir;

    //public bool NavigationCheckPosition(Character target, out NavMeshHit nmHit)
    //{
    //    nmHit = new NavMeshHit();
    //    if (!target) return false;

    //    Vector3 targetPos = target.transform.position;
    //    return NavigationCheckPosition(targetPos, out nmHit);
    //}

    public bool NavigationCheckPosition(Vector3 targetPos, out NavMeshHit nmHit)
    {
        return NavMesh.SamplePosition(targetPos, out nmHit, 1F, navAreas);
    }

    //private void NavigationCalculatePath(NavMeshHit nmHit)
    //{
    //    NavigationCalculatePath(nmHit.position);
    //}
    
    private void NavigationCalculatePath(Vector3 targetPos)
    {
        NavigationClear();

        bool positionCheck = NavigationCheckPosition(targetPos, out NavMeshHit hit);
        if (!positionCheck) return;

        Vector3 myPos = transform.position;
        Vector3 finalPos = hit.position;

        hasNavPath = NavMesh.CalculatePath(myPos, finalPos, navAreas, navigationPath);
        if (hasNavPath)
        {
            Vector3[] navPathCorners = navigationPath.corners;
            navigationFirstPos = navPathCorners.Length > 1 ? navPathCorners[1] : myPos;
            navigationLastPos = finalPos;
            navigationDir = (navigationFirstPos - myPos).normalized;
        }

        ////Fix for floaty NavMesh.
        //navigationFirstPos.y = myPos.y;
        //navigationLastPos.y = myPos.y;
    }
    
    private void NavigationClear()
    {
        Vector3 myPos = transform.position;
        hasNavPath = false;
        navigationPath.ClearCorners();
        navigationFirstPos = myPos;
        navigationLastPos = myPos;
        navigationDir = Vector3.zero;
    }

    private void NavigationRefresh()
    {
        if (decisionAction.IsMove())
        {
            bool useDecisionTarget = decisionTarget && decisionState == AIState.ENGAGE;
            if (useDecisionTarget)
                NavigationCalculatePath(decisionTarget.transform.position);
            else
                NavigationCalculatePath(decisionPos);
        }
        else
        {
            NavigationClear();
        }
    }
}
