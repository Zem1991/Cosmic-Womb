using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private Transform scenePointer;

    [Header("Screen")]
    [SerializeField] private Vector2 screenPos;
    [SerializeField] private Vector2 edgeCheck;
    [SerializeField] private Ray screenRay;

    [Header("Scene")]
    [SerializeField] private bool hasScreenRayHit;
    [SerializeField] private Vector3 scenePos;

    #region Screen
    public Vector2 GetScreenPosition()
    {
        return screenPos;
    }
    public Vector2 GetEdgeCheck()
    {
        return edgeCheck;
    }
    public Ray GetScreenRay()
    {
        return screenRay;
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

    public void UpdateCursor(Camera camera)
    {
        ReadCursorScreen();
        ReadCursorScene(camera);

        scenePointer.transform.position = scenePos;
    }
}
