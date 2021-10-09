using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    //[Header("Physics")]
    
    public void ApplyForce(Vector3 direction, float strength)
    {
        Vector3 force = direction * strength;
        _rigidbody.AddForce(force, ForceMode.Force);
    }
}
