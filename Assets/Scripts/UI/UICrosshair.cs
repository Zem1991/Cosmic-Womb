using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICrosshair : MonoBehaviour
{
    public void UpdateCrosshair(Vector2 screenPosition, float scale)
    {
        transform.position = screenPosition;
        transform.localScale = Vector3.one * scale;
    }
}
