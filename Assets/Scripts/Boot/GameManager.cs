using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AbstractSingleton<GameManager>
{
    [Header("Game data")]
    [SerializeField] private int levelIndex;
    [SerializeField] private int levelCount;

    public override void Awake()
    {
        base.Awake();
        Debug.Log("GameManager finished Awake()");
    }

    private void Start()
    {
        Debug.Log("GameManager entered Start()");
        //TODO: This is here for testing purposes.
        LoadNextLevel();
    }

    public int GetLevelCount()
    {
        return levelCount;
    }

    public void LoadNextLevel()
    {
        SceneLoader sceneLoader = SceneLoader.Instance;

        levelIndex++;
        if (levelIndex > levelCount) levelIndex = 1;
        string levelName = sceneLoader.GetLevelSceneName(levelIndex);
        LoadLevel(levelName);
    }

    //TODO: send this method to SceneLoader
    private void LoadLevel(string levelName)
    {
        SceneLoader sceneLoader = SceneLoader.Instance;

        Action onFinishAction = () =>
        {
            LevelController levelController = LevelController.Instance;
            LevelSpawnPosition spawnPosition = levelController.GetSpawnPosition();

            PlayerManager.Instance.SpawnAllPlayers(spawnPosition);
            levelController.StartLevel();
            Debug.Log("Level \"" + levelName + "\" was started.");
        };

        IEnumerator loadScene = sceneLoader.LoadLevelScene(levelName, onFinishAction);
        StartCoroutine(loadScene);
    }
}