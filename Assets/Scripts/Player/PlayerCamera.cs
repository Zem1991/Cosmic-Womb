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
        Vector3 cameraHolderPos = cameraHolder.transform.position;
        Vector3 cameraForward = cameraHolderPos - myPos;

        Gizmos.color = GizmosColors.cameraRange;
        GizmosExtensions.DrawWireArc(myPos, -cameraForward.normalized, 360, cameraRange, 24);

        Gizmos.color = GizmosColors.cameraPosition;
        Gizmos.DrawWireSphere(cameraHolderPos, 0.25F);
    }
    
    public Camera GetCamera()
    {
        return camera;
    }
    
    public void SetPosition(Vector3 charPos, Vector3 aimPos)
    {
        aimPos.y = charPos.y;
        //transform.position = charPos;

        Vector3 cameraPos = (aimPos + charPos) / 2F;
        Vector3 offset = cameraPos - charPos;
        if (offset.magnitude > cameraRange)
        {
            Vector3 offsetClamp = Vector3.ClampMagnitude(offset, cameraRange);
            cameraPos = transform.position + offsetClamp;
        }
        //transform.position = cameraPos;
        cameraHolder.transform.position = cameraPos;
    }

    public void Rotate(float rotation)
    {
        cameraHolder.transform.Rotate(Vector3.up, rotation, Space.World);
    }

    public Vector3 GetCameraHolderRotation()
    {
        return cameraHolder.rotation.eulerAngles;
    }
    
    public Vector2 GetScreenPointFromScenePoint(Vector3 scenePoint)
    {
        return camera.WorldToScreenPoint(scenePoint);
    }
}
