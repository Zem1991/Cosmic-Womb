using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private float interactionRange = 1F;
    [SerializeField] private AbstractInteractable interactionTarget;
    [SerializeField] private Vector3 interactionPos;
    
    private void SearchInteractable()
    {
        Vector3 mcPos = mainCharacter.GetTargetablePosition();
        Vector3 mcDir = mainCharacter.GetForwardDirection();

        string[] layerNames = {"Interactable"};
        LayerMask layerMask = LayerMask.GetMask(layerNames);

        Collider[] colliders = Physics.OverlapSphere(mcPos, interactionRange, layerMask, QueryTriggerInteraction.Collide);
        List<AbstractInteractable> interactableList = new List<AbstractInteractable>();
        foreach (Collider forCol in colliders)
        {
            AbstractInteractable forInteractable = forCol.GetComponent<AbstractInteractable>();
            if (!forInteractable) continue;
            interactableList.Add(forInteractable);
        }

        if (interactableList.Count > 1)
        {
            //TODO: This allows the player to interact with anything that is just close enough, regardless of facing directions.
            //However, this prioritizes interactables that are exactly in front of the main character. Do I still need this?
            interactableList.Sort((p1, p2) =>
            {
                Vector3 dirP1 = p1.transform.position - mcPos;
                float dotP1 = Vector3.Dot(mcDir, dirP1);

                Vector3 dirP2 = p2.transform.position - mcPos;
                float dotP2 = Vector3.Dot(mcDir, dirP2);

                return dotP1.CompareTo(dotP2);
            });
            interactableList.Reverse();
        }

        if (interactableList.Count > 0)
        {
            interactionTarget = interactableList[0];
            interactionPos = interactionTarget.GetComponent<Collider>().ClosestPoint(mcPos);
        }
        else
        {
            interactionTarget = null;
            interactionPos = Vector3.zero;
        }
    }
    
    private void Interaction()
    {
        if (!interactionTarget) return;

        bool interactPress = inputReader.InteractPress();
        bool interactHold = inputReader.InteractHold();
        //TODO: I might require differentiating between button press and button hold for different possible interactions.

        if (interactPress) interactionTarget.Interact();
    }
}
