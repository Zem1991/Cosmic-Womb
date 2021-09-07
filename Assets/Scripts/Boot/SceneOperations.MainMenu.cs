using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneOperations : AbstractSingleton<SceneOperations>
{
    public bool CheckMainMenu()
    {
        sceneMainMenu = SceneManager.GetSceneByName(SCENE_MAIN_MENU);
        sceneMainMenuHandle = sceneMainMenu.handle;
        return sceneMainMenuHandle != 0;
    }

    public AsyncOperation UnloadMainMenu()
    {
        if (!CheckMainMenu()) return null;
        return UnloadSceneAsync(SCENE_MAIN_MENU);
    }

    public AsyncOperation LoadMainMenu()
    {
        return LoadSceneAsync(SCENE_MAIN_MENU);
    }

    //public IEnumerator UnloadMainMenu()
    //{
    //    IEnumerator unloadScene = UnloadScene(sceneMainMenu);
    //    yield return StartCoroutine(unloadScene);

    //    sceneMainMenu = new Scene();
    //    sceneMainMenuHandle = sceneMainMenu.handle;
    //}

    //public IEnumerator LoadMainMenu(bool setActive, Action onFinish = null)
    //{
    //    if (CheckMainMenu(setActive))
    //    {
    //        //TODO: do something else here?
    //        onFinish?.Invoke();
    //    }
    //    else
    //    {
    //        Action onLoadMain = () =>
    //        {
    //            CheckMainMenu(setActive);
    //            onFinish?.Invoke();
    //            Debug.Log("Scene \"" + SCENE_MAIN_MENU + "\" is ready.");
    //        };

    //        IEnumerator loadScene = LoadScene(SCENE_MAIN_MENU, onLoadMain);
    //        yield return StartCoroutine(loadScene);
    //    }
    //}
}
