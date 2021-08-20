using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private new Camera camera;

    [Header("Settings")]
    [SerializeField] private float cameraRange = 12.5F;

    private void OnDrawGizmos()
    {
        Vector3 myPos = transform.position;
        Vector3 chPos = cameraHolder.transform.position;

        Gizmos.color = GizmoColors.cameraRange;
        Gizmos.DrawWireSphere(myPos, cameraRange);

        Gizmos.color = GizmoColors.cameraPosition;
        Gizmos.DrawWireSphere(chPos, 0.25F);
    }

    public void SetPosition(Vector3 charPos, Vector3 aimPos)
    {
        aimPos.y = charPos.y;
        transform.position = charPos;

        //Vector3 cameraPos = (cursorPos + charPos) / 2F;
        //Vector3 offset = cameraPos - charPos;
        //if (offset.magnitude > cameraRange)
        //{
        //    Vector3 offsetClamp = Vector3.ClampMagnitude(offset, cameraRange);
        //    cameraPos = transform.position + offsetClamp;
        //}
        //cameraHolder.transform.position = cameraPos;
    }

    public void Rotate(float rotation)
    {
        cameraHolder.transform.Rotate(Vector3.up, rotation, Space.World);
    }

    public Vector3 GetRotation()
    {
        return cameraHolder.rotation.eulerAngles;
    }
}
