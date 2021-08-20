using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDir;

    private void UpdateMovement()
    {
        Vector3 speed = moveDir * moveSpeed;
        //speed *= Time.deltaTime;
        characterController.SimpleMove(speed);

        float speedMagnitude = speed.magnitude;
        DecreaseAim(speedMagnitude);
    }

    public void StopMovement()
    {
        moveDir = Vector3.zero;
    }

    public void MoveAt(Vector3 direction)
    {
        moveDir = Vector3.ClampMagnitude(direction, 1);
    }

    //public void MoveTo(Vector3 position)
    //{
    //    Vector3 direction = position - transform.position;
    //    MoveAt(direction);
    //}
}
