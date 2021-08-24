using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private AbstractInteractable interactable;
    [SerializeField] private float interactableSearchDistance = 1F;
    
    private void SearchInteractable()
    {
        Vector3 mcPos = mainCharacter.GetTargetablePosition();
        Vector3 mcDir = mainCharacter.GetForwardDirection();

        string[] layerNames = {"Interactable"};
        LayerMask layerMask = LayerMask.GetMask(layerNames);

        Collider[] colliders = Physics.OverlapSphere(mcPos, interactableSearchDistance, layerMask, QueryTriggerInteraction.Collide);
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
            interactable = interactableList[0];
        else
            interactable = null;
    }
    
    private void Interaction()
    {
        if (!interactable) return;

        bool interactPress = inputReader.InteractPress();
        bool interactHold = inputReader.InteractHold();
        //TODO: I might require differentiating between button press and button hold for different possible interactions.

        if (interactPress) interactable.Interact();
    }
}
