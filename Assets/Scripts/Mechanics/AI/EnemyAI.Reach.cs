using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Reach")]
    [SerializeField] private AbstractCharacter reachableEnemy;

    public bool ReachTarget(AbstractCharacter target)
    {
        bool hasNavigation = ReachPosition(target.transform.position);
        if (hasNavigation)
        {
            reachableEnemy = target;
            //NavigationCalculatePath(nmHit);
        }
        else
        {
            reachableEnemy = null;
            //NavigationClear();
        }
        return hasNavigation;
    }

    public bool ReachPosition(Vector3 position)
    {
        bool hasNavigation = NavigationCheckPosition(position, out NavMeshHit nmHit);
        return hasNavigation;
    }

    public void ReachEnemy()
    {
        reachableEnemy = null;
        foreach (AbstractCharacter forChar in detectedCharacterList)
        {
            bool hasReachableEnemy = ReachTarget(forChar);
            if (hasReachableEnemy) break;
        }
    }
}
