using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AbstractSingleton<GameManager>
{
    [Header("Game data")]
    //TODO: these two variables are kinda useless now, because BootManager/SceneOperations also have these.
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

    public void RestartLevel()
    {
        ToLevel(levelCurrent);
    }

    public void ToIntermission()
    {
        //TODO: for now I dropped the idea about having the Intermission/Shop stuff.
        ToNextLevel();

        //BootManager bootManager = BootManager.Instance;
        //bootManager.BootIntermission();
    }

    public void QuitGame()
    {
        BootManager bootManager = BootManager.Instance;
        bootManager.BootMainMenu();
    }
}
