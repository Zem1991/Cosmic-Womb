using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    //[Header("Rotation")]
    //[SerializeField] private float moveSpeed;

    //public void RotateAt(Vector3 direction)
    //{
    //    throw new NotImplementedException();
    //}

    private void UpdateRotation()
    {
        Vector3 myPos = transform.position;
        Vector3 targetPos = aimPos;
        targetPos.y = myPos.y;
        float distance = Vector3.Distance(myPos, targetPos);
        if (distance < 0.1F) return;
        transform.LookAt(targetPos);
    }

    public Vector3 GetForwardDirection()
    {
        return transform.forward;
    }

    //public void RotateTo(Vector3 position)
    //{
    //    Vector3 myPos = transform.position;
    //    position.y = myPos.y;
    //    float distance = Vector3.Distance(myPos, position);
    //    if (distance < 0.1F) return;
    //    transform.LookAt(position);
    //}
}
