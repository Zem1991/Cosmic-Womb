using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : SceneUI
{
    [Header("Panels")]
    [SerializeField] private UIPanel_LevelResults levelResults;

    public void UpdateLevelResults(LevelController levelController)
    {
        levelResults.ManualUpdate(levelController);
    }
}
