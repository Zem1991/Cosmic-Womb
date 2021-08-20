using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Navigation")]
    [SerializeField] private bool hasNavPath;
    [SerializeField] private NavMeshPath navPath;
    [SerializeField] private Vector3 navPathFirstPos;
    [SerializeField] private Vector3 navPathFirstDir;

    public bool NavigationCheckPosition(Character target, out NavMeshHit nmHit)
    {
        nmHit = new NavMeshHit();
        if (!target) return false;

        Vector3 targetPos = target.transform.position;
        return NavigationCheckPosition(targetPos, out nmHit);
    }

    public bool NavigationCheckPosition(Vector3 targetPos, out NavMeshHit nmHit)
    {
        return NavMesh.SamplePosition(targetPos, out nmHit, 1, NavMesh.AllAreas);
    }

    private void NavigationCalculatePath(NavMeshHit nmHit)
    {
        NavigationCalculatePath(nmHit.position);
    }
    
    private void NavigationCalculatePath(Vector3 targetPos)
    {
        NavigationClear();
        Vector3 myPos = transform.position;

        //TODO: is this necessary?
        //if (Vector3.Distance(targetPos, myPos) < stopDistance) return;

        hasNavPath = NavMesh.CalculatePath(myPos, targetPos, NavMesh.AllAreas, navPath);
        if (hasNavPath)
        {
            Vector3[] navPathCorners = navPath.corners;
            navPathFirstPos = navPathCorners.Length > 1 ? navPathCorners[1] : myPos;
            navPathFirstPos.y = myPos.y;
            navPathFirstDir = (navPathFirstPos - myPos).normalized;
        }
        //else
        //{
        //    navPath.ClearCorners();
        //    navPathFirstPos = myPos;
        //    navPathFirstDir = Vector3.zero;
        //}
    }
    
    private void NavigationClear()
    {
        Vector3 myPos = transform.position;
        hasNavPath = false;
        navPath.ClearCorners();
        navPathFirstPos = myPos;
        navPathFirstDir = Vector3.zero;
    }
}
