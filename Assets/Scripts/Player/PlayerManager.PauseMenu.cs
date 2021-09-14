using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerManager : AbstractSingleton<PlayerManager>
{
    public void Resume()
    {
        uiHandler.TogglePauseMenu(false);
    }

    public void Restart()
    {
        uiHandler.TogglePauseMenu(false);

        GameManager gameManager = GameManager.Instance;
        gameManager.Restart();
    }

    public void QuitGame()
    {
        uiHandler.TogglePauseMenu(false);

        GameManager gameManager = GameManager.Instance;
        gameManager.QuitGame();
    }
}
