using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneOperations : AbstractSingleton<SceneOperations>
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

    public void SetActiveScene(Scene scene)
    {
        SceneManager.SetActiveScene(scene);
    }
    
    private AsyncOperation UnloadSceneAsync(string sceneName)
    {
        AsyncOperation result = SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        result.allowSceneActivation = false;
        return result;
    }

    private AsyncOperation LoadSceneAsync(string sceneName)
    {
        AsyncOperation result = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        result.allowSceneActivation = false;
        return result;
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
            Debug.Log("Scene \"" + sceneName + "\" loading progress: " + (asyncOperation.progress * 100) + "%.");

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                Debug.Log("Scene \"" + sceneName + "\" loading progress: 100%.");
                //Debug.Log("Pretend you had to press Spacebar to continue from load.");
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
