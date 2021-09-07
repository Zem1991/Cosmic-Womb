using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainMenu : MonoBehaviour
{
    private void Game()
    {
        uiHandler.HideAll();

        BootManager bootManager = BootManager.Instance;
        bootManager.BootGameAndPlayer();
    }
}
