using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ShopMenu : MonoBehaviour
{
    [Header("Scene references")]
    [SerializeField] private SceneUI uiHandler;

    public void NextLevel()
    {
        uiHandler.HideAll();

        GameManager gameManager = GameManager.Instance;
        gameManager.ToNextLevel();
    }

    public void QuitGame()
    {
        GameManager gameManager = GameManager.Instance;
        gameManager.QuitGame();
    }
}
