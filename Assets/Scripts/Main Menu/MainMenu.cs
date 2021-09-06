using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainMenu : MonoBehaviour
{
    [Header("Scene references")]
    [SerializeField] private SceneUI uiHandler;

    private void Start()
    {
        uiHandler.ShowAll();
    }

    public void NewGame()
    {
        Debug.Log("NewGame() called");
        Game();
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame() called");
        Application.Quit();
    }
}
