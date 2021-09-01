using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private UIPanel_LevelResults levelResults;

    public void HideAll()
    {
        gameObject.SetActive(false);
    }

    public void ShowAll()
    {
        gameObject.SetActive(true);
    }

    public void UpdateLevelResults(LevelController levelController)
    {
        levelResults.ManualUpdate(levelController);
    }
}
