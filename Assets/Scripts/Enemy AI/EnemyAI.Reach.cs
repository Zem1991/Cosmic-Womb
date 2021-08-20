using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Reach")]
    [SerializeField] private Character reachableEnemy;

    public bool ApplyReach(Character target)
    {
        bool hasNavigation = NavigationCheckPosition(target, out NavMeshHit nmHit);
        if (hasNavigation)
        {
            reachableEnemy = target;
            NavigationCalculatePath(nmHit);
        }
        else
        {
            reachableEnemy = null;
            NavigationClear();
        }
        return hasNavigation;
    }

    public void ReachEnemy()
    {
        reachableEnemy = null;
        foreach (Character forChar in detectedCharacterList)
        {
            bool hasReachableEnemy = ApplyReach(forChar);
            if (hasReachableEnemy) break;
        }
    }
}
