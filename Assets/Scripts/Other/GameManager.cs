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

    public void NewGame()
    {
        //TODO: more stuff here?
        ToLevel(1);
    }
    
    //TODO: send this method to SceneLoader
    public void ToLevel(int levelIndex)
    {
        levelCurrent = levelIndex;

        CoroutineHelper coroutineHelper = CoroutineHelper.Instance;
        SceneLoader sceneLoader = SceneLoader.Instance;

        IEnumerator loadLevel = sceneLoader.LoadLevel(levelIndex);

        Action onFinishAction = () =>
        {
            LevelController levelController = LevelController.Instance;
            levelController.StartLevel();
        };
        
        IEnumerator yieldCoroutines = coroutineHelper.YieldCoroutines(loadLevel, onFinishAction);
        StartCoroutine(yieldCoroutines);
    }

    public void ToNextLevel()
    {
        levelCurrent++;
        if (levelCurrent > levelCount) levelCurrent = 1;
        ToLevel(levelCurrent);
    }
}
