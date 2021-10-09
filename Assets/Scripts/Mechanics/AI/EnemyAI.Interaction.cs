using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private float interactionRange = 1F;
    [SerializeField] private Vector3 interactionPos;
    [SerializeField] private AbstractInteractable interactionTarget;
    [SerializeField] private DoorInteractable interactionDoor;

    private void SearchInteractable()
    {
        Vector3 myPos = character.GetTargetablePosition();
        Vector3 myDir = character.GetForwardDirection();

        string[] layerNames = {"Interactable"};
        LayerMask layerMask = LayerMask.GetMask(layerNames);

        bool hasInteractable = Physics.Raycast(myPos, myDir, out RaycastHit raycastHit, interactionRange, layerMask);
        if (!hasInteractable)
        {
            interactionPos = Vector3.zero;
            interactionTarget = null;
            interactionDoor = null;
            return;
        }

        Collider collider = raycastHit.collider;
        interactionPos = collider.ClosestPoint(myPos);
        interactionTarget = collider.GetComponent<AbstractInteractable>();
        interactionDoor = interactionTarget as DoorInteractable;
    }

    private bool CanOpenDoor()
    {
        return interactionDoor && interactionDoor.CanInteract() && interactionDoor.IsIdle() && !interactionDoor.IsOpen();
    }
}
