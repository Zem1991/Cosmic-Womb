using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundPropagator
{
    public static void Propagate(Vector3 position, float radius)
    {
        string[] layerNames = { "Character" };
        LayerMask layerMask = LayerMask.GetMask(layerNames);

        Collider[] colliders = Physics.OverlapSphere(position, radius, layerMask, QueryTriggerInteraction.Collide);
        //List<EnemyAI> aiList = new List<EnemyAI>();
        foreach (Collider forCol in colliders)
        {
            EnemyAI forAI = forCol.GetComponent<EnemyAI>();
            if (forAI) forAI.Hear(position);
        }
    }
}
