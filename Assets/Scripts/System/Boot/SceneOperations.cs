using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneOperations : MonoBehaviour
{
    public const string SCENE_MAIN_MENU = "Main Menu";
    public const string SCENE_GAME = "Game Management";
    public const string SCENE_PLAYER = "Player Management";
    public const string SCENE_LEVEL = "Level";
    public const string SCENE_INTERMISSION = "Intermission";

    [Header("Scene references")]
    [SerializeField] private Scene sceneMainMenu;
    [SerializeField] private int sceneMainMenuHandle;
    [SerializeField] private Scene sceneGame;
    [SerializeField] private int sceneGameHandle;
    [SerializeField] private Scene scenePlayer;
    [SerializeField] private int scenePlayerHandle;
    [SerializeField] private Scene sceneLevel;
    [SerializeField] private int sceneLevelHandle;
    [SerializeField] private Scene sceneIntermission;
    [SerializeField] private int sceneIntermissionHandle;
    
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
    
    private void SetActiveScene(Scene scene)
    {
        //TODO: this, but scenes actually ready to go
        //SceneManager.SetActiveScene(scene);
    }
}
