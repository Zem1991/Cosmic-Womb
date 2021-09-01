using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AbstractSingleton<GameManager>
{
    [Header("Self references")]
    [SerializeField] private SceneLoader sceneLoader;

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
        levelIndex++;
        if (levelIndex > levelCount) levelIndex = 1;
        string levelName = sceneLoader.GetLevelSceneName(levelIndex);
        LoadLevel(levelName);
    }

    private void LoadLevel(string levelName)
    {
        Action onFinishAction = () =>
        {
            Debug.Log("Level \"" + levelName + "\" was loaded.");
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
