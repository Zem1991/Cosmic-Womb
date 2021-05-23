using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private Transform sceneCursor;
    [SerializeField] private Transform aimCursor;

    [Header("Settings")]
    [SerializeField] private float aimHeight;

    [Header("Screen")]
    [SerializeField] private Vector2 screenPos;
    [SerializeField] private Vector2 edgeCheck;

    [Header("Scene")]
    [SerializeField] private Ray screenRay;
    [SerializeField] private bool hasScreenRayHit;
    [SerializeField] private Vector3 scenePos;

    [Header("Aim")]
    [SerializeField] private Vector3 aimPos;
    [SerializeField] private float aimDisplacement;
    //[SerializeField] private Vector3 aimTargetPos;

    #region Screen
    public Vector2 GetScreenPosition()
    {
        return screenPos;
    }
    public Vector2 GetEdgeCheck()
    {
        return edgeCheck;
    }
    private void ReadCursorScreen()
    {
        screenPos = Input.mousePosition;

        edgeCheck = new Vector2();
        if (screenPos.x <= 0) edgeCheck.x--;
        if (screenPos.x >= Screen.width - 1) edgeCheck.x++;
        if (screenPos.y <= 0) edgeCheck.y--;
        if (screenPos.y >= Screen.height - 1) edgeCheck.y++;
        edgeCheck.Normalize();
    }
    #endregion

    #region Scene
    public Vector3 GetScenePosition()
    {
        return scenePos;
    }
    private void ReadCursorScene(Camera camera)
    {
        screenRay = camera.ScreenPointToRay(screenPos);
        hasScreenRayHit = Physics.Raycast(screenRay, out RaycastHit raycastHitSingle, Mathf.Infinity);
        scenePos = raycastHitSingle.point;
    }
    #endregion

    #region Aim
    public Vector3 GetAimPosition()
    {
        return aimPos;
    }
    private void ReadCursorAim()
    {
        Vector3 aimPosBefore = aimPos;

        Plane xzPlane = new Plane(Vector3.down, aimHeight);
        xzPlane.Raycast(screenRay, out float planeRaycastPoint);
        aimPos = screenRay.GetPoint(planeRaycastPoint);

        aimDisplacement = Vector3.Distance(aimPosBefore, aimPos);
    }
    #endregion

    public void ReadCursor(Camera camera)
    {
        ReadCursorScreen();
        ReadCursorScene(camera);
        ReadCursorAim();

        sceneCursor.gameObject.SetActive(hasScreenRayHit);
        sceneCursor.transform.position = scenePos;

        aimCursor.gameObject.SetActive(hasScreenRayHit);
        aimCursor.transform.position = aimPos;

        //if (!hasScreenRayHit) return;
    }
}
