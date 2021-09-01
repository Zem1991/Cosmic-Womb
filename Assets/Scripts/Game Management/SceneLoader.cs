using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public const string SCENE_MAIN = "Main";
    //public const string SCENE_GAME = "Game";
    //public const string SCENE_PLAYER = "Player";
    public const string SCENE_LEVEL = "Level";
    //public const string SCENE_SHOP = "Shop";

    [Header("Scene references")]
    //[SerializeField] private Scene scenePlayer;
    //[SerializeField] private int scenePlayerHandle;
    [SerializeField] private Scene sceneLevel;
    [SerializeField] private int sceneLevelHandle;
    //[SerializeField] private Scene sceneShop;
    //[SerializeField] private int sceneShopHandle;

    private void Awake()
    {
        CheckExistingScenes();
        Debug.Log("SceneLoader finished Awake()");
    }

    public string GetLevelSceneName(int levelIndex)
    {
        string result = SCENE_LEVEL + " ";
        if (levelIndex < 10) result += "0";
        result += levelIndex;
        return result;
    }

    public IEnumerator LoadLevelScene(string levelName, Action onFinish)
    {
        //Unload the current level first, for safety. Regardless if the Shop scene was loaded or not.
        IEnumerator unloadCurrentLevel = UnloadScene(sceneLevel);
        yield return unloadCurrentLevel;

        //Proceed with the next level, and also with any parallel stuff that is required.
        IEnumerator loadNextLevel = LoadScene(levelName);
        IEnumerator[] enumerators = { loadNextLevel };

        Action onFinishYieldAll = () =>
        {
            CheckExistingScenes();
        };

        IEnumerator fullCoroutine = YieldCoroutines(enumerators, onFinishYieldAll);
        yield return StartCoroutine(fullCoroutine);

        onFinish();
    }

    private void CheckExistingScenes()
    {
        //scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
        //scenePlayerHandle = scenePlayer.handle;
        sceneLevel = CheckExistingLevelScene();
        sceneLevelHandle = sceneLevel.handle;
        //sceneShop = SceneManager.GetSceneByName(SCENE_SHOP);
        //sceneShopHandle = sceneShop.handle;
    }

    private Scene CheckExistingLevelScene()
    {
        int levelCount = GameManager.Instance.GetLevelCount();
        Scene result = new Scene();
        for (int levelIndex = 1; levelIndex <= levelCount; levelIndex++)
        {
            string levelName = GetLevelSceneName(levelIndex);
            Scene attempt = SceneManager.GetSceneByName(levelName);
            if (attempt.handle == 0) continue;

            result = attempt;
            break;
        }
        return result;
    }

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

    private IEnumerator LoadScene(string sceneName)
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
        Debug.Log("Scene \"" + sceneName + "\" was loaded.");
    }

    //TODO: move this to a more appropriate class
    private IEnumerator YieldCoroutines(IEnumerator[] enumerators, Action onFinish)
    {
        List<Coroutine> coroutineList = new List<Coroutine>();
        foreach (IEnumerator forEnumerator in enumerators)
        {
            Coroutine coroutine = StartCoroutine(forEnumerator);
            coroutineList.Add(coroutine);
        }

        foreach (Coroutine forCoroutine in coroutineList)
        {
            yield return forCoroutine;
        }

        onFinish();
    }
}
