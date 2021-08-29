using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererToggleLevelEvent : AbstractLevelEvent
{
    [Header("Renderer Toggle settings")]
    [SerializeField] protected bool toggleValue;

    public override bool TriggerEvent()
    {
        base.TriggerEvent();

        BoxCollider myCollider = GetComponent<BoxCollider>();
        Bounds myBounds = myCollider.bounds;
        Collider[] colliders = Physics.OverlapBox(myBounds.center, myBounds.extents);

        List<Renderer> rendererList = new List<Renderer>();
        foreach (Collider forCollider in colliders)
        {
            Renderer[] renderers = forCollider.GetComponentsInChildren<Renderer>();
            rendererList.AddRange(renderers);
        }

        foreach (Renderer forRenderer in rendererList)
        {
            forRenderer.enabled = toggleValue;
        }

        return true;
    }
}
