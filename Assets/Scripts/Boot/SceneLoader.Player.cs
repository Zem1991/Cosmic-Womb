using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneLoader : AbstractSingleton<SceneLoader>
{
    public IEnumerator LoadPlayer(Action onFinish = null)
    {
        if (CheckPlayer())
        {
            //TODO: do something else here?
            onFinish?.Invoke();
        }
        else
        {
            Action onLoadPlayer = () =>
            {
                CheckPlayer();
                onFinish?.Invoke();
                Debug.Log("Scene \"" + SCENE_PLAYER + "\" is ready.");
            };

            IEnumerator loadScene = LoadScene(SCENE_PLAYER, onLoadPlayer);
            yield return StartCoroutine(loadScene);
        }
    }

    private bool CheckPlayer()
    {
        scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
        scenePlayerHandle = scenePlayer.handle;
        return scenePlayerHandle != 0;
    }
}
