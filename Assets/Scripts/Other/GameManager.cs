using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AbstractSingleton<GameManager>
{
    [Header("Game data")]
    [SerializeField] private int levelCurrent;
    [SerializeField] private int levelCount;

    public override void Awake()
    {
        base.Awake();
        Debug.Log("GameManager finished Awake()");
    }
    
    public void ToLevel(int levelIndex)
    {
        BootManager bootManager = BootManager.Instance;
        bootManager.BootLevel(levelIndex);
    }

    public void ToNextLevel()
    {
        levelCurrent++;
        if (levelCurrent > levelCount) levelCurrent = 1;
        ToLevel(levelCurrent);
    }
}
