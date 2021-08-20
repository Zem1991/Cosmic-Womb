using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Self References")]
    [SerializeField] private Character character;

    private void OnDrawGizmos()
    {
        GizmosDetection();
        GizmosNavigation();
    }

    private void Awake()
    {
        navPath = new UnityEngine.AI.NavMeshPath();
        NavigationClear();
    }

    private void Update()
    {
        //TODO: what I was trying to achieve here could just be too much overthinking, and even if it worked it could introduce many bugs to further work on.
        //bool needsNewDecision = !CheckCurrentDecision();
        //if (needsNewDecision)
        //{
        //    //These two methods could be overriden by somehting like having orders from an officer, being stunned, etc.
        //    GatherInfo();
        //    ProcessInfo();

        //    //Use all the information gathered and processed to select what to do next.
        //    TakeNewDecision();
        //}

        //These two methods could be overriden by somehting like having orders from an officer, being stunned, etc.
        GatherInfo();
        ProcessInfo();

        //Use all the information gathered and processed to select what to do next.
        TakeNewDecision();

        //Perform whatever action decided, including doing nothing.
        Execute();
    }

    private void GatherInfo()
    {
        //Perform detection - sight, hearing, etc.
        FullDetection();

        //Get knowledge about other stuff via external sources.
        //TODO: ...
    }

    private void ProcessInfo()
    {
        //First it goes for a enemy within attack distance. Then it goes for a enemy at least within attack range.

        //TODO: maybe I don't need to verify all of that, because Unity's Navigation already goes for the closest position possible,
        //even if no actual path to the exact target point is available.

        //Filter known enemies that can be attacked
        //TODO: ...

        //Locks on the first enemy that is reachable by moving.
        ReachEnemy();
    }
}
