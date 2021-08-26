using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundPropagator
{
    public static void Propagate(Vector3 position, float radius)
    {
        string[] characterLayer = { "Character" };
        LayerMask characterLayerMask = LayerMask.GetMask(characterLayer);

        string[] defaultLayer = { "Default" };
        LayerMask defaultLayerMask = LayerMask.GetMask(defaultLayer);

        Collider[] colliders = Physics.OverlapSphere(position, radius, characterLayerMask, QueryTriggerInteraction.Collide);
        foreach (Collider forCol in colliders)
        {
            Character forChara = forCol.GetComponent<Character>();
            EnemyAI forAI = forCol.GetComponent<EnemyAI>();
            if (!forChara || !forAI) continue;

            Vector3 finalPos = forChara.GetTargetablePosition();
            Vector3 direction = finalPos - position;
            float distance = Vector3.Distance(position, finalPos);

            RaycastHit[] raycastHits = Physics.RaycastAll(position, direction, radius, defaultLayerMask);
            int obstacleCount = raycastHits.Length;

            float effectiveRadius = radius / (obstacleCount + 1);
            if (effectiveRadius >= distance) forAI.Hear(position);
        }
    }
}
