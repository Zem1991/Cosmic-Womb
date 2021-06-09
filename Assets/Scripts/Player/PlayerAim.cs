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

    public void UpdateAim(Ray screenRay, Vector3 aimStart, Vector3 aimEnd)
    {
        ReadCursorAim(screenRay);
        Vector3[] positions = { aimStart, aimEnd };
        aimPointer.transform.position = aimPos;
        weaponTrajectory.SetPositions(positions);
    }

    #region Aim
    public Vector3 GetAimPosition()
    {
        return aimPos;
    }
    private void ReadCursorAim(Ray screenRay)
    {
        //Vector3 aimPosBefore = aimPos;

        Plane xzPlane = new Plane(Vector3.down, aimHeight);
        xzPlane.Raycast(screenRay, out float planeRaycastPoint);
        aimPos = screenRay.GetPoint(planeRaycastPoint);

        //aimDisplacement = Vector3.Distance(aimPosBefore, aimPos);
    }
    #endregion
}
