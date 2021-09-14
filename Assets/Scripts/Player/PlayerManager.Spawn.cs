using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerManager : AbstractSingleton<PlayerManager>
{
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
