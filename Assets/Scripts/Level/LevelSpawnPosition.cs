using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnPosition : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3 myPos = GetPosition();
        Vector3 myDir = GetDirection();
        
        Vector3 lineStart = myPos;
        lineStart.y += 0.5F;
        Vector3 lineEnd = myPos + myDir;

        Gizmos.color = GizmosColors.spawnPosition;
        Gizmos.DrawLine(lineStart, lineEnd);
        Gizmos.DrawWireSphere(myPos, 0.5F);
        GizmosExtensions.DrawWireArc(myPos, -myDir, 360F, 1F, 3);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetDirection()
    {
        return transform.forward;
    }
}
