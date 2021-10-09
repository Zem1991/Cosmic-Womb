using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainMenu : MonoBehaviour
{
    //TODO: unless I add some more complexity to the process of starting a Game, this partial class is unnecessary.
    private void Game()
    {
        uiHandler.HideAll();

        BootManager bootManager = BootManager.Instance;
        bootManager.BootGameAndPlayer();
    }
}
