using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        GizmosInteraction();
    }

    private void GizmosInteraction()
    {
        if (!playerCharacter) return;

        Vector3 myPos = playerCharacter.transform.position;
        Vector3 mcDir = playerCharacter.GetForwardDirection();

        Gizmos.color = GizmosColors.interactionRange;
        GizmosExtensions.DrawWireArc(myPos, -mcDir, 360, interactionRange, 24);

        if (interactionTarget)
        {
            Vector3 cubePos = interactionPos;
            Vector3 cubeSize = Vector3.one * 1F;
            Gizmos.color = GizmosColors.interactionTarget;
            Gizmos.DrawWireCube(cubePos, cubeSize);
        }
    }
}
