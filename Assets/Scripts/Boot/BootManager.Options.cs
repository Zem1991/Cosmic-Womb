using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BootManager : AbstractSingleton<BootManager>
{
    public void BootMainMenu(Action onFinish)
    {
        List<AsyncOperation> unloadGameAndPlayer = UnloadAllGameplay();
        List<AsyncOperation> loadMainMenu = LoadMainMenu();

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadGameAndPlayer);
        asyncOperations.AddRange(loadMainMenu);
        StartLoading("Going to the Main Menu", asyncOperations, onFinish);
    }

    public void BootGameAndPlayer(Action onFinish)
    {
        List<AsyncOperation> unloadMainMenu = UnloadMainMenu();
        List<AsyncOperation> loadGameAndPlayer = LoadGameAndPlayer();

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadMainMenu);
        asyncOperations.AddRange(loadGameAndPlayer);
        StartLoading("Preparing the Game", asyncOperations, onFinish);
    }

    public void BootLevel(int levelIndex, Action onFinish)
    {
        List<AsyncOperation> unloadCurrentLevel = UnloadLevel();
        List<AsyncOperation> loadNextLevel = LoadLevel(levelIndex);

        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();
        asyncOperations.AddRange(unloadCurrentLevel);
        asyncOperations.AddRange(loadNextLevel);
        StartLoading("Loading the level", asyncOperations, onFinish);
    }
}
