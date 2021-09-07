using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneOperations : MonoBehaviour
{
    public bool CheckGame()
    {
        sceneGame = SceneManager.GetSceneByName(SCENE_GAME);
        sceneGameHandle = sceneGame.handle;
        return sceneGameHandle != 0;
    }

    public AsyncOperation UnloadGame()
    {
        if (!CheckGame()) return null;
        return UnloadSceneAsync(SCENE_GAME);
    }

    public AsyncOperation LoadGame()
    {
        if (CheckGame()) return null;
        return LoadSceneAsync(SCENE_GAME);
    }

    public void SetGameAsActiveScene()
    {
        SetActiveScene(sceneGame);
    }

    //public IEnumerator LoadGame()
    //{
    //    IEnumerator unloadScene = UnloadScene(sceneGame);
    //    yield return StartCoroutine(unloadScene);

    //    sceneGame = new Scene();
    //    sceneGameHandle = sceneGame.handle;
    //}

    //public IEnumerator LoadGame(bool setActive, Action onFinish = null)
    //{
    //    if (CheckGame(setActive))
    //    {
    //        //TODO: do something else here?
    //        onFinish?.Invoke();
    //    }
    //    else
    //    {
    //        Action onLoadGame = () =>
    //        {
    //            CheckGame(setActive);
    //            onFinish?.Invoke();
    //            Debug.Log("Scene \"" + SCENE_GAME + "\" is ready.");
    //        };

    //        IEnumerator loadScene = LoadScene(SCENE_GAME, onLoadGame);
    //        yield return StartCoroutine(loadScene);
    //    }
    //}

    //private bool CheckGame(bool setActive)
    //{
    //    sceneGame = SceneManager.GetSceneByName(SCENE_GAME);
    //    sceneGameHandle = sceneGame.handle;

    //    if (sceneGameHandle != 0)
    //    {
    //        if (setActive) SceneManager.SetActiveScene(sceneGame);
    //        return true;
    //    }
    //    return false;
    //}
}
