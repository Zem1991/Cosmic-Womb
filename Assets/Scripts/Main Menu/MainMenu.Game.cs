using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainMenu : MonoBehaviour
{
    private void Game()
    {
        CoroutineHelper coroutineHelper = CoroutineHelper.Instance;
        SceneLoader sceneLoader = SceneLoader.Instance;

        IEnumerator loadGameMgmt = sceneLoader.LoadGame(true);
        IEnumerator loadPlayerMgmt = sceneLoader.LoadPlayer();

        List<IEnumerator> enumeratorList = new List<IEnumerator>();
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
