using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneOperations : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private int currentLevelIndex = 1;
    [SerializeField] private int levelCount = 1;

    public int GetCurrentLevelIndex()
    {
        return currentLevelIndex;
    }

    public string GetLevelSceneName(int levelIndex)
    {
        string result = SCENE_LEVEL + " ";
        if (levelIndex < 10) result += "0";
        result += levelIndex;
        return result;
    }

    public bool CheckLevel()
    {
        bool result = false;
        for (int levelIndex = 1; levelIndex <= levelCount; levelIndex++)
        {
            result = CheckLevel(levelIndex);
            if (result) break;
        }
        return result;
    }

    public bool CheckLevel(int levelIndex)
    {
        string levelName = GetLevelSceneName(levelIndex);
        sceneLevel = SceneManager.GetSceneByName(levelName);
        sceneLevelHandle = sceneLevel.handle;
        bool result = sceneLevelHandle != 0;
        if (result)
            currentLevelIndex = levelIndex;
        else
            currentLevelIndex = 0;
        return result;
    }
    
    public AsyncOperation UnloadLevel(int levelIndex)
    {
        if (!CheckLevel(levelIndex)) return null;
        currentLevelIndex = 0;
        string levelName = GetLevelSceneName(levelIndex);
        return UnloadSceneAsync(levelName);
    }
    
    public AsyncOperation LoadLevel(int levelIndex)
    {
        if (CheckLevel(levelIndex)) return null;
        currentLevelIndex = levelIndex;
        string levelName = GetLevelSceneName(levelIndex);
        return LoadSceneAsync(levelName);
    }
    
    //public IEnumerator UnloadLevel()
    //{
    //    IEnumerator unloadScene = UnloadScene(sceneLevel);
    //    yield return StartCoroutine(unloadScene);

    //    sceneLevel = new Scene();
    //    sceneLevelHandle = sceneLevel.handle;
    //}

    //public IEnumerator LoadLevel(int levelIndex, Action onFinish = null)
    //{
    //    string levelName = GetLevelSceneName(levelIndex);
    //    if (CheckLevel(levelName))
    //    {
    //        //TODO: do something else here?
    //        onFinish?.Invoke();
    //    }
    //    else
    //    {
    //        Action onLoadLevel = () =>
    //        {
    //            CheckLevel(levelName);
    //            onFinish?.Invoke();
    //            Debug.Log("Scene \"" + levelName + "\" is ready.");

    //            //if (startLevel)
    //            //{
    //            //    LevelController levelController = LevelController.Instance;
    //            //    levelController.StartLevel();
    //            //}
    //        };

    //        IEnumerator loadScene = LoadScene(levelName, onLoadLevel);
    //        yield return StartCoroutine(loadScene);
    //    }
    //}

    //private bool CheckLevel(string levelName)
    //{
    //    sceneLevel = SceneManager.GetSceneByName(levelName);
    //    sceneLevelHandle = sceneLevel.handle;
    //    return sceneLevelHandle != 0;
    //}

    ////private Scene FindLevelScene()
    ////{
    ////    int levelCount = GameManager.Instance.GetLevelCount();
    ////    Scene result = new Scene();
    ////    for (int levelIndex = 1; levelIndex <= levelCount; levelIndex++)
    ////    {
    ////        string levelName = GetLevelSceneName(levelIndex);
    ////        Scene attempt = SceneManager.GetSceneByName(levelName);
    ////        if (attempt.handle == 0) continue;

    ////        result = attempt;
    ////        break;
    ////    }
    ////    return result;
    ////}
}
