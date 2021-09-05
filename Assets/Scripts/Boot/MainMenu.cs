using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("NewGame()");
        SceneLoader sceneLoader = SceneLoader.Instance;
        sceneLoader.LoadGame(true);
        sceneLoader.LoadPlayer();
        sceneLoader.LoadLevel(1);
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame()");
        Application.Quit();
    }
}
