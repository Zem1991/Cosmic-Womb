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
}
