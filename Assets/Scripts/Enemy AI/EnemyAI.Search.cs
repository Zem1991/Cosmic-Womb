using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Search: settings")]
    [SerializeField] private float searchStateTimeMax = 30F;
    [SerializeField] private float searchAreaSize = 5F;

    [Header("Search: current")]
    //[SerializeField] private Vector3 searchPos;
    //[SerializeField] private Character searchTarget;
    [SerializeField] private float searchStateTimeCurrent;
    [SerializeField] private float searchActionTimeCurrent;

    private bool BeginSearch(Character target)
    {
        if (!target) return false;

        Vector3 searchPosFirst = target.GetMoveDir() * target.GetMoveSpeed();
        searchPosFirst += target.transform.position;

        decisionState = AIState.SEARCH;
        decisionAction = AIAction.MOVE_AND_ROTATE;
        decisionPos = searchPosFirst;
        decisionTarget = target;

        //searchPos = searchPosFirst;
        //searchTarget = target;
        searchStateTimeCurrent = searchStateTimeMax;
        searchActionTimeCurrent = 0;
        return true;
    }

    private bool SearchTimer()
    {
        searchStateTimeCurrent -= Time.deltaTime;
        searchActionTimeCurrent -= Time.deltaTime;
        return searchStateTimeCurrent > 0;
    }

    private void EndSearch()
    {
        //searchPos = Vector3.zero;
        //searchTarget = null;
        searchStateTimeCurrent = 0;
        searchActionTimeCurrent = 0;
    }

    private void SearchAction()
    {
        Vector3 myPos = transform.position;

        if (decisionAction == AIAction.MOVE_AND_ROTATE)
        {
            bool hasNavigation = hasNavPath || NavigationCheckPosition(decisionPos, out NavMeshHit nmHit);
            if (!hasNavigation)
            {
                //Can't move there. But can rotate and face towards it.
                SearchActionRotate();
                return;
            }

            bool hasDistance = Vector3.Distance(myPos, decisionPos) > stopDistance;
            if (!hasDistance)
            {
                //It's too close already. Do nothing for a while.
                SearchActionNone();
                return;
            }

            //Will keep moving towards the position returned within nmHit.
            SearchActionMoveAndRotate();
            return;
        }

        if (decisionAction == AIAction.ROTATE)
        {
            bool rotationCheck = character.CheckRotationTo(decisionPos);
            if (rotationCheck)
            {
                //It's already facing towards decisionPos. Do nothing for a while.
                SearchActionNone();
                return;
            }

            //Will keep rotating towards the position stored into decisionPos.
            SearchActionRotate();
            return;
        }

        if (decisionAction == AIAction.NONE)
        {
            if (searchActionTimeCurrent > 0) return;

            //Selects a random position around itself and store it into decisionPos.
            Vector2 searchOffset = Random.insideUnitCircle * searchAreaSize;
            decisionPos = myPos;
            decisionPos.x += searchOffset.x;
            decisionPos.z += searchOffset.y;

            //Will start moving towards the new search position on the next frame, if possible.
            SearchActionMoveAndRotate();
            //decisionAction = AIAction.MOVE_AND_ROTATE;    //TODO: can I take this out?
            return;
        }
    }

    private void SearchActionMoveAndRotate()
    {
        decisionAction = AIAction.MOVE_AND_ROTATE;
        //NavigationCalculatePath(decisionPos);
    }

    private void SearchActionRotate()
    {
        decisionAction = AIAction.ROTATE;
        //NavigationCalculatePath(decisionPos);   //TODO: is this required here?
    }

    private void SearchActionNone()
    {
        decisionAction = AIAction.NONE;
        searchActionTimeCurrent = Random.Range(1F, 5F);
    }
}
