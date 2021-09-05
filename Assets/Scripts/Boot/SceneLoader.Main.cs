using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneLoader : AbstractSingleton<SceneLoader>
{
    public void LoadMain(bool setActive)
    {
        if (CheckMain(setActive))
        {
            //TODO: something else?
            return;
        }

        Action onFinishAction = () =>
        {
            CheckMain(setActive);
            Debug.Log("\"" + SCENE_MAIN + "\" is ready.");
        };

        IEnumerator loadScene = LoadScene(SCENE_MAIN, onFinishAction);
        StartCoroutine(loadScene);
    }

    private bool CheckMain(bool setActive)
    {
        sceneMain = SceneManager.GetSceneByName(SCENE_MAIN);
        sceneMainHandle = sceneMain.handle;

        if (sceneMainHandle != 0)
        {
            if (setActive) SceneManager.SetActiveScene(sceneMain);
            return true;
        }
        return false;
    }
}
