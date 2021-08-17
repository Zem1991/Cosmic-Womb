using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private Transform aimPointer;
    [SerializeField] private LineRenderer weaponTrajectory;
    [SerializeField] private LineRenderer grenadeTrajectory;

    [Header("Settings")]
    [SerializeField] private float aimHeight;

    [Header("Aim")]
    [SerializeField] private Vector3 aimPos;
    //[SerializeField] private float aimDisplacement;
    //[SerializeField] private Vector3 aimTargetPos;
    
    #region Aim
    public Vector3 GetAimPosition()
    {
        return aimPos;
    }
    private void ReadCursorAim(Ray screenRay, float startHeight)
    {
        //Vector3 aimPosBefore = aimPos;

        float height = startHeight + aimHeight;
        Plane xzPlane = new Plane(Vector3.down, height);
        xzPlane.Raycast(screenRay, out float planeRaycastPoint);
        aimPos = screenRay.GetPoint(planeRaycastPoint);

        //aimDisplacement = Vector3.Distance(aimPosBefore, aimPos);
    }
    #endregion

    public void UpdateAim(Ray screenRay, float startHeight)
    {
        ReadCursorAim(screenRay, startHeight);

        aimPointer.transform.position = aimPos;
    }
    
    public void DrawAimLine(Vector3 aimStart, Vector3 aimEnd)
    {
        Vector3[] positions = { aimStart, aimEnd };
        weaponTrajectory.SetPositions(positions);
    }
}
