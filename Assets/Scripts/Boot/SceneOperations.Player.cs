using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneOperations : MonoBehaviour
{
    public bool CheckPlayer()
    {
        scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
        scenePlayerHandle = scenePlayer.handle;
        return scenePlayerHandle != 0;
    }

    public AsyncOperation UnloadPlayer()
    {
        if (!CheckPlayer()) return null;
        return UnloadSceneAsync(SCENE_PLAYER);
    }

    public AsyncOperation LoadPlayer()
    {
        if (CheckPlayer()) return null;
        return LoadSceneAsync(SCENE_PLAYER);
    }

    //public IEnumerator UnloadPlayer()
    //{
    //    IEnumerator unloadScene = UnloadScene(scenePlayer);
    //    yield return StartCoroutine(unloadScene);

    //    scenePlayer = new Scene();
    //    scenePlayerHandle = scenePlayer.handle;
    //}

    //public IEnumerator LoadPlayer(Action onFinish = null)
    //{
    //    if (CheckPlayer())
    //    {
    //        //TODO: do something else here?
    //        onFinish?.Invoke();
    //    }
    //    else
    //    {
    //        Action onLoadPlayer = () =>
    //        {
    //            CheckPlayer();
    //            onFinish?.Invoke();
    //            Debug.Log("Scene \"" + SCENE_PLAYER + "\" is ready.");
    //        };

    //        IEnumerator loadScene = LoadScene(SCENE_PLAYER, onLoadPlayer);
    //        yield return StartCoroutine(loadScene);
    //    }
    //}

    //private bool CheckPlayer()
    //{
    //    scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
    //    scenePlayerHandle = scenePlayer.handle;
    //    return scenePlayerHandle != 0;
    //}
}
