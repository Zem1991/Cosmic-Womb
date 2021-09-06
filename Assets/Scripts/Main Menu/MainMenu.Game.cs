using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainMenu : MonoBehaviour
{
    private void Game()
    {
        uiHandler.HideAll();

        CoroutineHelper coroutineHelper = CoroutineHelper.Instance;
        SceneLoader sceneLoader = SceneLoader.Instance;

        //IEnumerator unloadMainMenu = sceneLoader.UnloadMainMenu();
        IEnumerator loadGameMgmt = sceneLoader.LoadGame(true);
        IEnumerator loadPlayerMgmt = sceneLoader.LoadPlayer();

        List<IEnumerator> enumeratorList = new List<IEnumerator>();
        //enumeratorList.Add(unloadMainMenu);
        enumeratorList.Add(loadGameMgmt);
        enumeratorList.Add(loadPlayerMgmt);

        Action onGame = () =>
        {
            GameManager gameManager = GameManager.Instance;
            gameManager.NewGame();
        };
        
        IEnumerator yieldCoroutines = coroutineHelper.YieldCoroutines(enumeratorList, onGame);
        StartCoroutine(yieldCoroutines);
    }
}
