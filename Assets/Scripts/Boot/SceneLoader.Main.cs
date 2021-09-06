using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneLoader : AbstractSingleton<SceneLoader>
{
    public IEnumerator LoadMain(bool setActive, Action onFinish = null)
    {
        if (CheckMain(setActive))
        {
            //TODO: do something else here?
            onFinish?.Invoke();
        }
        else
        {
            Action onLoadMain = () =>
            {
                CheckMain(setActive);
                onFinish?.Invoke();
                Debug.Log("Scene \"" + SCENE_MAIN_MENU + "\" is ready.");
            };

            IEnumerator loadScene = LoadScene(SCENE_MAIN_MENU, onLoadMain);
            yield return StartCoroutine(loadScene);
        }
    }

    private bool CheckMain(bool setActive)
    {
        sceneMainMenu = SceneManager.GetSceneByName(SCENE_MAIN_MENU);
        sceneMainMenuHandle = sceneMainMenu.handle;

        if (sceneMainMenuHandle != 0)
        {
            if (setActive) SceneManager.SetActiveScene(sceneMainMenu);
            return true;
        }
        return false;
    }
}
