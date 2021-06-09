using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    
    private void ActualMovement()
    {
        Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 position = transform.position + movement;
        _rigidbody.MovePosition(position);
    }
    
    private bool CheckDeflection(GameObject collidedObject, Vector3 hitNormal)
    {
        Character collidedChara = collidedObject.GetComponent<Character>();
        if (!collidedChara) return false;
        float deflectionAngle = 0;// collidedChara.GetDeflectionArc();
        if (deflectionAngle <= 0) return false;

        deflectionAngle /= 2F;
        Vector3 forward = collidedObject.transform.forward;
        float hitAngle = Vector3.Angle(forward, hitNormal);
        return deflectionAngle >= hitAngle;
    }
}
