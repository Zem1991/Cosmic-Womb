using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BootManager : AbstractSingleton<BootManager>
{
    [Header("Scene references")]
    [SerializeField] private BootUI uiHandler;
    [SerializeField] private CoroutineHelper coroutineHelper;
    [SerializeField] private SceneOperations sceneOperations;
    
    private void Start()
    {
        //Doing this inside Awake() may generate an error, because some scene is not yet ready.
        CheckFirstBoot();
        Debug.Log("BootManager finished Start()");
    }

    private void Update()
    {
        UpdateLoading();
    }

    private void CheckFirstBoot()
    {
        bool hasGameMgmt = sceneOperations.CheckGame();
        bool hasPlayerMgmt = sceneOperations.CheckPlayer();
        bool hasLevel = sceneOperations.CheckLevel();
        bool hasShop = false;

        bool hasLevelOrShopButNotBoth = hasLevel ^ hasShop;
        bool doGameplay = hasGameMgmt && hasPlayerMgmt && hasLevelOrShopButNotBoth;

        if (doGameplay)
        {
            Debug.Log("First boot is Gameplay");
            BootGameAndPlayer();
        }
        else
        {
            Debug.Log("First boot is Main Menu");
            BootMainMenu(null);
        }
    }
}
