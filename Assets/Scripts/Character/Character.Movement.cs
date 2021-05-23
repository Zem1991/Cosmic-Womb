using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    public void MoveAt(Vector3 direction)
    {
        Vector3 speed = direction * moveSpeed;
        //speed *= Time.deltaTime;
        characterController.SimpleMove(speed);

        float speedMagnitude = speed.magnitude;
        DecreaseAim(speedMagnitude);
    }

    public void MoveTo(Vector3 position)
    {
        throw new NotImplementedException();
    }

    public void RotateAt(Vector3 direction)
    {
        throw new NotImplementedException();
    }

    public void RotateTo(Vector3 position)
    {
        Vector3 myPos = transform.position;
        position.y = myPos.y;
        float distance = Vector3.Distance(myPos, position);
        if (distance < 0.1F) return;
        transform.LookAt(position);
    }
}
