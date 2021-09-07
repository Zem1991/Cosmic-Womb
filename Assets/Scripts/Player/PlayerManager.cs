using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AbstractSingleton<PlayerManager>
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

    #region Scene references
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
    #endregion

    public bool DespawnAllPlayers()
    {
        uiHandler.HideAll();
        playerCamera.gameObject.SetActive(false);
        playerCursor.gameObject.SetActive(false);
        playerAim.gameObject.SetActive(false);

        //TODO: if this game ever get co-op mode, make this method work for any player instead of just localPlayer.
        Player player = localPlayer;
        
        player.Despawn();
        return true;
    }

    public bool SpawnAllPlayers(LevelSpawnPosition spawnPosition)
    {
        uiHandler.ShowAll();
        playerCamera.gameObject.SetActive(true);
        playerCursor.gameObject.SetActive(true);
        playerAim.gameObject.SetActive(true);

        //TODO: if this game ever get co-op mode, make this method work for any player instead of just localPlayer.
        Player player = localPlayer;

        Vector3 position = spawnPosition.GetPosition();
        Vector3 direction = spawnPosition.GetDirection();

        player.Spawn(position, direction);
        return true;
    }
}
