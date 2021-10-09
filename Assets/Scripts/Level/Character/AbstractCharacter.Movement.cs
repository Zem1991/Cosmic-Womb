using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private FloatProperty movementSpeed;
    [SerializeField] private Vector3 moveDir;

    public float GetMoveSpeed()
    {
        return movementSpeed.Value;
    }
    
    public Vector3 GetMoveDir()
    {
        return moveDir;
    }

    private void UpdateMovement()
    {
        Vector3 speed = moveDir * GetMoveSpeed();
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
