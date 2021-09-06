using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneLoader : AbstractSingleton<SceneLoader>
{
    public const string SCENE_MAIN_MENU = "Main Menu";
    public const string SCENE_GAME = "Game Management";
    public const string SCENE_PLAYER = "Player Management";
    public const string SCENE_LEVEL = "Level";
    //public const string SCENE_SHOP = "Shop";

    [Header("Scene references")]
    [SerializeField] private Scene sceneMainMenu;
    [SerializeField] private int sceneMainMenuHandle;
    [SerializeField] private Scene sceneGame;
    [SerializeField] private int sceneGameHandle;
    [SerializeField] private Scene scenePlayer;
    [SerializeField] private int scenePlayerHandle;
    [SerializeField] private Scene sceneLevel;
    [SerializeField] private int sceneLevelHandle;
    //[SerializeField] private Scene sceneShop;
    //[SerializeField] private int sceneShopHandle;

    private void Start()
    {
        IEnumerator loadMainMenu = LoadMain(true);
        StartCoroutine(loadMainMenu);
        Debug.Log("SceneLoader finished Start()");
    }

    //public IEnumerator LoadLevelScene(string levelName, Action onFinish)
    //{
    //    //Unload the current level first, for safety. Regardless if the Shop scene was loaded or not.
    //    IEnumerator unloadCurrentLevel = UnloadScene(sceneLevel);
    //    yield return unloadCurrentLevel;

    //    //Proceed with the next level, and also with any parallel stuff that is required.
    //    IEnumerator loadNextLevel = LoadScene(levelName);
    //    IEnumerator[] enumerators = { loadNextLevel };

    //    Action onFinishYield = () =>
    //    {
    //        //TODO: some singletons could be missing
    //        //CheckExistingScenes();
    //    };

    //    IEnumerator fullCoroutine = YieldCoroutines(enumerators, onFinishYield);
    //    yield return StartCoroutine(fullCoroutine);

    //    onFinish?.Invoke();
    //}

    ////TODO: check if this is still required
    //private void CheckExistingScenes()
    //{
    //    sceneMain = SceneManager.GetSceneByName(SCENE_MAIN);
    //    sceneMainHandle = scenePlayer.handle;
    //    sceneGame = SceneManager.GetSceneByName(SCENE_GAME);
    //    sceneGameHandle = scenePlayer.handle;
    //    scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
    //    scenePlayerHandle = scenePlayer.handle;
    //    sceneLevel = FindLevelScene();
    //    sceneLevelHandle = sceneLevel.handle;
    //    //sceneShop = SceneManager.GetSceneByName(SCENE_SHOP);
    //    //sceneShopHandle = sceneShop.handle;
    //}
    
    private IEnumerator UnloadScene(Scene scene)
    {
        int sceneHandle = scene.handle;
        if (sceneHandle == 0)
        {
            yield return null;
        }
        else
        {
            string sceneName = scene.name;
            //Debug.Log("Scene \"" + sceneHandle + "\" to be unloaded.");
            //yield return SceneManager.UnloadSceneAsync(sceneHandle, UnloadSceneOptions.None);   
            Debug.Log("Scene \"" + sceneName + "\" to be unloaded.");
            yield return SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);   
            Debug.Log("Scene \"" + sceneName + "\" was unloaded.");
        }
    }

    private IEnumerator LoadScene(string sceneName, Action onFinish = null)
    {
        //Begin to load the Scene you specify. Also don't let the Scene activate until you allow it to.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;

        //While the load is still in progress, output the progress in the debug console.
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            Debug.Log("Loading progress: " + (asyncOperation.progress * 100) + "%.");

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                Debug.Log("Pretend you had to press Spacebar to continue from load.");
                asyncOperation.allowSceneActivation = true;
            }

            //Wait for end of frame
            yield return null;
        }

        //Wait one extra frame, so it has time to become active.
        yield return null;
        Debug.Log("Scene \"" + sceneName + "\" was loaded.");
        onFinish?.Invoke();
    }
}
