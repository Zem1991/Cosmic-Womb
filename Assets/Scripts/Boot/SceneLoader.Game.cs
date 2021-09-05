using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneLoader : AbstractSingleton<SceneLoader>
{
    public void LoadGame(bool setActive)
    {
        if (CheckGame(setActive))
        {
            //TODO: something else?
            return;
        }

        Action onFinishAction = () =>
        {
            CheckGame(setActive);
            Debug.Log("\"" + SCENE_GAME + "\" is ready.");
        };

        IEnumerator loadScene = LoadScene(SCENE_GAME, onFinishAction);
        StartCoroutine(loadScene);
    }

    private bool CheckGame(bool setActive)
    {
        sceneGame = SceneManager.GetSceneByName(SCENE_GAME);
        sceneGameHandle = sceneGame.handle;

        if (sceneGameHandle != 0)
        {
            if (setActive) SceneManager.SetActiveScene(sceneGame);
            return true;
        }
        return false;
    }
}
