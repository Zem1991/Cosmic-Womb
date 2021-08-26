using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Search: settings")]
    [SerializeField] private float searchStateTimeMax = 20F;
    [SerializeField] private float searchAreaSize = 10F;
    [SerializeField] private int decisionPositionAttempts = 3;

    [Header("Search: current")]
    //[SerializeField] private Character searchTarget;
    [SerializeField] private Vector3 startingSearchPos;
    [SerializeField] private Vector3 previousSearchPos;
    [SerializeField] private float searchStateTimeCurrent;
    [SerializeField] private float searchActionTimeCurrent;

    private bool BeginSearch(Character target, Vector3 targetPos)
    {
        targetPos = NavigationSnapPosition(targetPos);

        //Vector3 decisionPosOffset = target.GetMoveDir() * target.GetMoveSpeed();
        startingSearchPos = targetPos;
        //decisionPos += decisionPosOffset;
        previousSearchPos = startingSearchPos;

        decisionState = AIState.SEARCH;
        decisionAction = AIAction.MOVE_AND_ROTATE;
        decisionPos = startingSearchPos;
        decisionTarget = target;

        //decisionPos = decisionPosFirst;
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
        //decisionPos = Vector3.zero;
        //searchTarget = null;
        searchStateTimeCurrent = 0;
        searchActionTimeCurrent = 0;
    }

    private void SearchAction()
    {
        Vector3 myPos = transform.position;

        if (decisionAction == AIAction.INTERACT)
        {
            //After interacting, resumes its navigation.
            SearchActionMoveAndRotate();
            return;
        }

        if (decisionAction == AIAction.MOVE_AND_ROTATE)
        {
            bool doorSituation = interactionDoor && !interactionDoor.IsOpen();
            if (doorSituation)
            {
                //Will interact with the door in front of itself for a single frame. Then it will keep moving like if the door didn't exist.
                SearchActionInteract();
                return;
            }

            //TODO: maybe I should do something about the cases where the current search position (decisionPos) is close enough but the path is very lengthy...

            bool hasNavigation = hasNavPath || NavigationCheckPosition(decisionPos, out NavMeshHit nmHit);
            if (!hasNavigation)
            {
                //Can't move there. But can rotate and face towards it.
                SearchActionRotate();
                return;
            }

            bool hasDistance = !hasNavPath || Vector3.Distance(myPos, navigationLastPos) > stopDistance;
            //bool hasTimeRemaining = searchActionTimeCurrent > 0;
            //if (!hasDistance || !hasTimeRemaining)
            if (!hasDistance)
            {
                //It's either too close already or just spent too much time going there. Do nothing for a while.
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

            //Will start moving towards the new search position on the next frame, if possible.
            GenerateSearchPosition();
            SearchActionMoveAndRotate();
            return;
        }
    }

    private void SearchActionInteract()
    {
        decisionAction = AIAction.INTERACT;
    }

    private void SearchActionMoveAndRotate()
    {
        decisionAction = AIAction.MOVE_AND_ROTATE;
    }

    private void SearchActionRotate()
    {
        decisionAction = AIAction.ROTATE;
    }

    private void SearchActionNone()
    {
        decisionAction = AIAction.NONE;
        searchActionTimeCurrent = Random.Range(1F, 5F);
    }

    private void GenerateSearchPosition()
    {
        Vector3 newSearchPos = startingSearchPos;
        float retryDistance = searchAreaSize / 2F;

        int attempts = 0;
        bool newPositionFound = false;
        while (!newPositionFound)
        {
            Vector2 searchOffset = Random.insideUnitCircle * searchAreaSize;
            newSearchPos = startingSearchPos;
            newSearchPos.x += searchOffset.x;
            newSearchPos.z += searchOffset.y;

            attempts++;
            if (attempts >= decisionPositionAttempts)
            {
                newPositionFound = true;
            }
            else
            {
                newPositionFound = Vector3.Distance(previousSearchPos, newSearchPos) >= retryDistance;
            }
        }

        previousSearchPos = decisionPos;
        decisionPos = newSearchPos;
    }
}
