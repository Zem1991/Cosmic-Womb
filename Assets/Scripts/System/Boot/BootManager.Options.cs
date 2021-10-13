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
        //If I unload a level while loading another, the 'currentLevelIndex' variable inside SceneOperations gets erased.
        //And this happens after being written with the next level index value.
        //This is why those operations run in sequence instead of in parallel.

        //TODO: This generates 2 loading bars, and I only need one
        BootLevelPart1(levelIndex);
    }

    private void BootLevelPart1(int levelIndex)
    {
        //TODO: make this method optional if no level scene or intermission scene exists
        List<AsyncOperation> unloadCurrentLevel = UnloadLevel();
        List<AsyncOperation> unloadIntermission = UnloadIntermission();

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadCurrentLevel);
        asyncOperations.AddRange(unloadIntermission);

        Action onFinish = () =>
        {
            Debug.Log("BootLevelPart1 calling it's onFinish");
            sceneOperations.CheckLevel();

            BootLevelPart2(levelIndex);
        };

        StartLoading("Preparing for the next level", asyncOperations, onFinish);
    }

    private void BootLevelPart2(int levelIndex)
    {
        List<AsyncOperation> loadNextLevel = LoadLevel(levelIndex);

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(loadNextLevel);

        Action onFinish = () =>
        {
            Debug.Log("BootLevelPart2 calling it's onFinish");
            sceneOperations.CheckLevel();

            LevelController levelController = LevelController.Instance;
            levelController.StartLevel();
        };

        string nextLevelSceneName = sceneOperations.GetLevelSceneName(levelIndex);
        string processName = "Now entering: " + nextLevelSceneName;
        StartLoading(processName, asyncOperations, onFinish);
    }
    
    public void BootIntermission()
    {
        List<AsyncOperation> unloadCurrentLevel = UnloadLevel();
        List<AsyncOperation> loadIntermission = LoadIntermission();

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadCurrentLevel);
        asyncOperations.AddRange(loadIntermission);

        Action onFinish = () =>
        {
            Debug.Log("BootIntermission calling it's onFinish");
            sceneOperations.CheckLevel();
            sceneOperations.CheckIntermission();

            //TODO: IntermissionManager start call?
        };

        StartLoading("Intermission...", asyncOperations, onFinish);
    }
}
