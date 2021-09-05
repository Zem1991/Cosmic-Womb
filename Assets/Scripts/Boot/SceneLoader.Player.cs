using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneLoader : AbstractSingleton<SceneLoader>
{
    public void LoadPlayer()
    {
        if (CheckPlayer())
        {
            //TODO: something else?
            return;
        }

        Action onFinishAction = () =>
        {
            CheckPlayer();
            Debug.Log("\"" + SCENE_PLAYER + "\" is ready.");
        };

        IEnumerator loadScene = LoadScene(SCENE_PLAYER, onFinishAction);
        StartCoroutine(loadScene);
    }

    private bool CheckPlayer()
    {
        scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
        scenePlayerHandle = scenePlayer.handle;
        return scenePlayerHandle != 0;
    }
}
