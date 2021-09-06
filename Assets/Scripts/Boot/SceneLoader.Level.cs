using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneLoader : AbstractSingleton<SceneLoader>
{
    public string GetLevelSceneName(int levelIndex)
    {
        string result = SCENE_LEVEL + " ";
        if (levelIndex < 10) result += "0";
        result += levelIndex;
        return result;
    }

    public IEnumerator LoadLevel(int levelIndex, Action onFinish = null)
    {
        string levelName = GetLevelSceneName(levelIndex);
        if (CheckLevel(levelName))
        {
            //TODO: do something else here?
            onFinish?.Invoke();
        }
        else
        {
            Action onLoadLevel = () =>
            {
                CheckLevel(levelName);
                onFinish?.Invoke();
                Debug.Log("Scene \"" + levelName + "\" is ready.");

                //if (startLevel)
                //{
                //    LevelController levelController = LevelController.Instance;
                //    levelController.StartLevel();
                //}
            };

            IEnumerator loadScene = LoadScene(levelName, onLoadLevel);
            yield return StartCoroutine(loadScene);
        }
    }

    private bool CheckLevel(string levelName)
    {
        sceneLevel = SceneManager.GetSceneByName(levelName);
        sceneLevelHandle = sceneLevel.handle;
        return sceneLevelHandle != 0;
    }

    //private Scene FindLevelScene()
    //{
    //    int levelCount = GameManager.Instance.GetLevelCount();
    //    Scene result = new Scene();
    //    for (int levelIndex = 1; levelIndex <= levelCount; levelIndex++)
    //    {
    //        string levelName = GetLevelSceneName(levelIndex);
    //        Scene attempt = SceneManager.GetSceneByName(levelName);
    //        if (attempt.handle == 0) continue;

    //        result = attempt;
    //        break;
    //    }
    //    return result;
    //}
}
