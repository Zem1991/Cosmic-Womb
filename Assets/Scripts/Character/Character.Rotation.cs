using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector3 rotPos;
    [SerializeField] private Vector3 rotPosPrevious;

    private void UpdateRotation()
    {
        Vector3 myPos = transform.position;
        Vector3 targetPos = rotPos;

        float distance = Vector3.Distance(myPos, targetPos);
        if (distance < 0.1F) return;

        transform.LookAt(targetPos);
        rotPosPrevious = rotPos;
    }

    //public void RotateAt(Vector3 direction)
    //{
    //    throw new NotImplementedException();
    //}

    public void RotateTo(Vector3 position, bool instant = false)
    {
        Vector3 myPos = transform.position;
        rotPos = position;
        rotPos.y = myPos.y;

        float distance = Vector3.Distance(myPos, rotPos);
        if (distance < 0.1F) return;

        if (instant) UpdateRotation();
    }

    public Vector3 GetForwardDirection()
    {
        return transform.forward;
    }
}
