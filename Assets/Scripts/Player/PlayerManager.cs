using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerManager : AbstractSingleton<PlayerManager>
{
    [Header("Scene references")]
    [SerializeField] private PlayerUI uiHandler;
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private PlayerCursor playerCursor;
    [SerializeField] private PlayerAim playerAim;

    [Header("Players")]
    [SerializeField] private Player localPlayer;

    public override void Awake()
    {
        //TODO: I will need something later for handling which player is being featured on the PlayerUI.
        //For now this is handled in the DespawnAllPlayers and SpawnAllPlayers methods.

        base.Awake();

        uiHandler.TogglePauseMenu(false);
        DespawnAllPlayers();

        Debug.Log("PlayerManager finished Awake()");
    }

    private void Update()
    {
        if (localPlayer)
        {
            Vector3 playerPos = localPlayer.transform.position;
            playerCamera.transform.position = playerPos;
            playerCursor.transform.position = playerPos;
            playerAim.transform.position = playerPos;
        }
    }

    public PlayerUI GetPlayerUI()
    {
        return uiHandler;
    }
    public PlayerCamera GetPlayerCamera()
    {
        return playerCamera;
    }
    public PlayerCursor GetPlayerCursor()
    {
        return playerCursor;
    }
    public PlayerAim GetPlayerAim()
    {
        return playerAim;
    }
}
