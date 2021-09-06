using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUI : MonoBehaviour
{
    public void HideAll()
    {
        gameObject.SetActive(false);
    }

    public void ShowAll()
    {
        gameObject.SetActive(true);
    }
}
