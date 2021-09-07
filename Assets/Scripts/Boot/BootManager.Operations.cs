using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BootManager : AbstractSingleton<BootManager>
{
    private List<AsyncOperation> UnloadMainMenu()
    {
        AsyncOperation unloadMainMenu = sceneOperations.UnloadMainMenu();

        List<AsyncOperation> result = new List<AsyncOperation>();
        if (unloadMainMenu != null) result.Add(unloadMainMenu);
        return result;
    }

    private List<AsyncOperation> LoadMainMenu()
    {
        AsyncOperation loadMainMenu = sceneOperations.LoadMainMenu();

        List<AsyncOperation> result = new List<AsyncOperation>();
        if (loadMainMenu != null) result.Add(loadMainMenu);
        return result;
    }

    private List<AsyncOperation> UnloadAllGameplay()
    {
        AsyncOperation unloadGame = sceneOperations.UnloadGame();
        AsyncOperation unloadPlayer = sceneOperations.UnloadPlayer();
        List<AsyncOperation> unloadLevelList = UnloadLevel();
        //TODO: unload Shop scene

        List<AsyncOperation> result = new List<AsyncOperation>();
        if (unloadGame != null) result.Add(unloadGame);
        if (unloadPlayer != null) result.Add(unloadPlayer);
        result.AddRange(unloadLevelList);
        //TODO: unload Shop scene
        return result;
    }

    private List<AsyncOperation> LoadGameAndPlayer()
    {
        AsyncOperation loadGame = sceneOperations.LoadGame();
        AsyncOperation loadPlayer = sceneOperations.LoadPlayer();

        List<AsyncOperation> result = new List<AsyncOperation>();
        if (loadGame != null) result.Add(loadGame);
        if (loadPlayer != null) result.Add(loadPlayer);
        return result;
    }

    private List<AsyncOperation> UnloadLevel()
    {
        int levelIndex = sceneOperations.GetCurrentLevelIndex();
        return UnloadLevel(levelIndex);
    }

    private List<AsyncOperation> UnloadLevel(int levelIndex)
    {
        AsyncOperation unloadLevel = sceneOperations.UnloadLevel(levelIndex);

        List<AsyncOperation> result = new List<AsyncOperation>();
        if (unloadLevel != null) result.Add(unloadLevel);
        return result;
    }

    private List<AsyncOperation> LoadLevel(int levelIndex)
    {
        AsyncOperation loadLevel = sceneOperations.LoadLevel(levelIndex);

        List<AsyncOperation> result = new List<AsyncOperation>();
        if (loadLevel != null) result.Add(loadLevel);
        return result;
    }

    //private List<AsyncOperation> UnloadShop()
    //{
    //    //TODO: SceneLoader magic

    //    List<AsyncOperation> result = new List<AsyncOperation>();
    //    return result;
    //}

    //private List<AsyncOperation> LoadShop(int levelIndex)
    //{
    //    //TODO: SceneLoader magic

    //    List<AsyncOperation> result = new List<AsyncOperation>();
    //    return result;
    //}
}
