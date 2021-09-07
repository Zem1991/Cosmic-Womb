using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BootManager : AbstractSingleton<BootManager>
{
    public void BootMainMenu()
    {
        List<AsyncOperation> unloadGameAndPlayer = UnloadAllGameplay();
        List<AsyncOperation> loadMainMenu = LoadMainMenu();

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadGameAndPlayer);
        asyncOperations.AddRange(loadMainMenu);

        Action onFinish = () =>
        {
            Debug.Log("BootMainMenu calling it's onFinish");
            sceneOperations.CheckMainMenu();
            sceneOperations.SetMainMenuAsActiveScene();
        };

        StartLoading("Going to the Main Menu", asyncOperations, onFinish);
    }

    public void BootGameAndPlayer()
    {
        List<AsyncOperation> unloadMainMenu = UnloadMainMenu();
        List<AsyncOperation> loadGameAndPlayer = LoadGameAndPlayer();

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadMainMenu);
        asyncOperations.AddRange(loadGameAndPlayer);

        Action onFinish = () =>
        {
            Debug.Log("BootGameAndPlayer calling it's onFinish");
            sceneOperations.CheckGame();
            sceneOperations.CheckPlayer();
            sceneOperations.SetGameAsActiveScene();

            //TODO: something to load other levels, especially one indicated by an save file.
            BootLevel(1);
        };

        StartLoading("Preparing the Game", asyncOperations, onFinish);
    }

    public void BootLevel(int levelIndex)
    {
        List<AsyncOperation> unloadCurrentLevel = UnloadLevel();
        List<AsyncOperation> loadNextLevel = LoadLevel(levelIndex);

        string processName = "Loading level " + levelIndex;

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadCurrentLevel);
        asyncOperations.AddRange(loadNextLevel);

        Action onFinish = () =>
        {
            Debug.Log("BootLevel calling it's onFinish");
            sceneOperations.CheckLevel();

            LevelController levelController = LevelController.Instance;
            levelController.StartLevel();
        };

        StartLoading(processName, asyncOperations, onFinish);
    }

    //public void BootLevel(int levelIndex)
    //{
    //    //If I unload a level while loading another, the 'currentLevelIndex' variable inside SceneOperations gets erased.
    //    //And this happens after being written with the next level index value.
    //    //This is why those operations run in sequence instead of in parallel.

    //    List<AsyncOperation> unloadCurrentLevel = UnloadLevel();
    //    List<AsyncOperation> loadNextLevel = LoadLevel(levelIndex);

    //    List<AsyncOperation> asyncOperations02 = new List<AsyncOperation>();
    //    asyncOperations02.AddRange(loadNextLevel);

    //    Action onFinish02 = () =>
    //    {
    //        Debug.Log("BootLevel calling it's onFinish02");
    //        LevelController levelController = LevelController.Instance;
    //        levelController.StartLevel();
    //    };

    //    List<AsyncOperation> asyncOperations01 = new List<AsyncOperation>();
    //    asyncOperations01.AddRange(unloadCurrentLevel);

    //    Action onFinish01 = () =>
    //    {
    //        Debug.Log("BootLevel calling it's onFinish01");
    //        string nextLevelSceneName = sceneOperations.GetLevelSceneName(levelIndex);
    //        string processName02 = "Loading " + nextLevelSceneName;
    //        StartLoading(processName02, asyncOperations02, onFinish02);
    //    };

    //    string processName01 = "Unloading current level";
    //    StartLoading(processName01, asyncOperations01, onFinish01);
    //}
}
