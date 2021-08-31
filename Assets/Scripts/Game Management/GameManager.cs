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
    }

    public int GetLevelCount()
    {
        return levelCount;
    }

    public void LoadNextLevel()
    {
        levelIndex++;
        if (levelIndex > levelCount) levelIndex = 1;
        string levelName = sceneLoader.GetLevelName(levelIndex);
        LoadLevel(levelName);
    }

    private void LoadLevel(string levelName)
    {
        IEnumerator levelLoad = sceneLoader.LoadLevel(levelName);
        StartCoroutine(levelLoad);
        Debug.Log("Level \"" + levelName + "\" started.");
    }
}
