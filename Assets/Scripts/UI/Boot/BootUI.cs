using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootUI : SceneUI
{
    [Header("Panels")]
    [SerializeField] private UIPanel_BootProgress bootProgress;

    public void UpdateBootProgress(int percent)
    {
        bootProgress.ManualUpdate(percent);
    }
}
