using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    [Header("Detection: settings")]
    [SerializeField] private float sightRange = 15F;
    [SerializeField] private float sightRadius = 120F;

    [Header("Detection: runtime")]
    [SerializeField] private bool heardSomethingBefore;
    [SerializeField] private bool heardSomethingNow;
    [SerializeField] private Vector3 hearingPos;
    [SerializeField] private List<Character> detectedCharacterList = new List<Character>();

    public void Unhear()
    {
        heardSomethingBefore = false;
        heardSomethingNow = false;
        hearingPos = Vector3.zero;
    }

    public void Hear(Vector3 position)
    {
        heardSomethingBefore = true;
        heardSomethingNow = true;
        hearingPos = position;
    }

    public bool CheckDetection(Character target)
    {
        if (!target) return false;

        Allegiance myAllegiance = character.GetAllegiance();
        Allegiance targetAllegiance = target.GetAllegiance();

        bool isEnemy = myAllegiance.CheckOpponent(targetAllegiance);
        if (!isEnemy) return false;

        Vector3 rayFrom = character.GetTargetablePosition();
        Vector3 rayTo = target.GetTargetablePosition();
        Vector3 rayDir = (rayTo - rayFrom).normalized;
        Ray ray = new Ray(rayFrom, rayDir);

        float angle = Vector3.Angle(character.GetForwardDirection(), rayDir);
        angle = Mathf.Abs(angle);
        float halfSightRadius = sightRadius / 2F;

        bool withinSightArc = angle < halfSightRadius;
        if (!withinSightArc) return false;

        //string[] sightLayerNames = {"Default", "Character", "Interactable"};
        string[] sightLayerNames = {"Default", "Character"};
        LayerMask sightMask = LayerMask.GetMask(sightLayerNames);

        bool withinSightRange = Physics.Raycast(ray, out RaycastHit hitInfo, sightRange, sightMask);
        if (!withinSightRange) return false;

        bool sightNotBlocked = hitInfo.collider.gameObject == target.gameObject;
        if (!sightNotBlocked) return false;

        return true;
    }

    private void FullDetection()
    {
        detectedCharacterList.Clear();
        Collider[] candidates = Physics.OverlapSphere(transform.position, sightRange);

        foreach (Collider item in candidates)
        {
            //Ignore self
            GameObject gObj = item.gameObject;
            if (gObj == gameObject) continue;

            //Must be an valid target
            Character possibleTarget = item.GetComponent<Character>();
            if (!possibleTarget) continue;

            bool detected = CheckDetection(possibleTarget);
            if (detected) detectedCharacterList.Add(possibleTarget);
        }
    }
}
