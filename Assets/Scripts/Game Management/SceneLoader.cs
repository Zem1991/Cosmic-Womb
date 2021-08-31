using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public const string SCENE_MAIN = "Main";
    //public const string SCENE_GAME = "Game";
    public const string SCENE_PLAYER = "Player";
    public const string SCENE_LEVEL = "Level";
    public const string SCENE_SHOP = "Shop";

    [Header("Scene references")]
    //[SerializeField] private Scene sceneMain;
    //[SerializeField] private Scene sceneGame;
    [SerializeField] private Scene scenePlayer;
    [SerializeField] private int scenePlayerHandle;
    [SerializeField] private Scene sceneLevel;
    [SerializeField] private int sceneLevelHandle;
    [SerializeField] private Scene sceneShop;
    [SerializeField] private int sceneShopHandle;

    private void Start()
    {
        //yield return null;
        CheckExistingScenes();
    }

    public string GetLevelName(int levelIndex)
    {
        string result = SCENE_LEVEL + " ";
        if (levelIndex < 10) result += "0";
        result += levelIndex;
        return result;
    }

    //TODO: load this together with the game scene?
    //public IEnumerator LoadPlayer()
    //{
    //    yield return LoadScene(SCENE_PLAYER);
    //    scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
    //}

    public IEnumerator LoadLevel(string levelName)
    {
        yield return UnloadScene(sceneLevel);
        //TODO: create the Shop scene
        //yield return UnloadScene(sceneShop);

        yield return LoadScene(levelName);
        //sceneLevel = SceneManager.GetSceneByName(levelName);
        //sceneLevelHandle = sceneLevel.handle;
        CheckExistingScenes();
    }

    public IEnumerator LoadShop()
    {
        yield return UnloadScene(sceneLevel);
        yield return UnloadScene(sceneShop);

        yield return LoadScene(SCENE_SHOP);
        //sceneShop = SceneManager.GetSceneByName(SCENE_SHOP);
        //sceneShopHandle = sceneLevel.handle;
        CheckExistingScenes();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Debug.Log("Scene \"" + sceneName + "\" was loaded.");
    }

    private IEnumerator UnloadScene(Scene scene)
    {
        int sceneHandle = scene.handle;
        if (sceneHandle == 0) yield return null;

        string sceneName = scene.name;
        yield return SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        Debug.Log("Scene \"" + sceneName + "\" was unloaded.");

        //if (sceneHandle == 0)
        //{
        //    yield return null;
        //}
        //else
        //{
        //    string sceneName = scene.name;
        //    yield return SceneManager.UnloadSceneAsync(sceneHandle, UnloadSceneOptions.None);
        //    Debug.Log("Scene \"" + sceneName + "\" was unloaded.");
        //}
    }

    private void CheckExistingScenes()
    {
        scenePlayer = SceneManager.GetSceneByName(SCENE_PLAYER);
        scenePlayerHandle = scenePlayer.handle;
        sceneLevel = CheckExistingLevelScene();
        sceneLevelHandle = sceneLevel.handle;
        sceneShop = SceneManager.GetSceneByName(SCENE_SHOP);
        sceneShopHandle = sceneShop.handle;
    }

    private Scene CheckExistingLevelScene()
    {
        int levelCount = GameManager.Instance.GetLevelCount();
        Scene result = new Scene();
        for (int levelIndex = 1; levelIndex <= levelCount; levelIndex++)
        {
            string levelName = GetLevelName(levelIndex);
            Scene attempt = SceneManager.GetSceneByName(levelName);
            if (attempt.handle == 0) continue;

            result = attempt;
            break;
        }
        return result;
    }
}
