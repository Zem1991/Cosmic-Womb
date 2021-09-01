using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    [Header("Players")]
    [SerializeField] private Player localPlayer;

    public bool SpawnPlayer(LevelSpawnPosition spawnPosition)
    {
        //TODO: if this game ever get co-op mode, make this method work for any player instead of just localPlayer.
        Player player = localPlayer;

        Vector3 position = spawnPosition.GetPosition();
        Vector3 direction = spawnPosition.GetDirection();

        player.Spawn(position, direction);
        return true;
    }
}
