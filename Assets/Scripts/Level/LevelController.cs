using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : AbstractSingleton<LevelController>
{
    [Header("Scene references")]
    [SerializeField] private LevelUI uiHandler;
    [SerializeField] private Transform mapCameraHolder;
    [SerializeField] private Camera mapCamera;
    [SerializeField] private Transform endCameraHolder;
    [SerializeField] private Camera endCamera;

    [Header("Level information")]
    [SerializeField] private string levelName = "Unnamed level";
    [SerializeField] private float completionTime = 30F;
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int secretsCount = 0;
    [SerializeField] private LevelSpawnPosition spawnPosition;

    [Header("Level data")]
    [SerializeField] private bool isCompleted = false;
    [SerializeField] private float playTime = 0F;
    [SerializeField] private int killCount = 0;
    [SerializeField] private int findingsCount = 0;

    public override void Awake()
    {
        base.Awake();

        uiHandler.HideAll();
        endCameraHolder.gameObject.SetActive(false);

        ////TODO: descommenting this is required when testing an level directly from its scene.
        //StartLevel();

        Debug.Log("LevelController finished Awake()");
    }

    private void Update()
    {
        if (!isCompleted)
        {
            playTime += Time.deltaTime;
        }
    }

    #region Level information
    public string GetLevelName()
    {
        return levelName;
    }
    public float GetCompletionTime()
    {
        return completionTime;
    }
    public int GetEnemyCount()
    {
        return enemyCount;
    }
    public int GetSecretsCount()
    {
        return secretsCount;
    }
    public LevelSpawnPosition GetSpawnPosition()
    {
        return spawnPosition;
    }
    #endregion

    #region Level data
    public float GetPlayTime()
    {
        return playTime;
    }
    public int GetKillCount()
    {
        return killCount;
    }
    public int GetFindingsCount()
    {
        return findingsCount;
    }
    #endregion

    public void StartLevel()
    {
        PlayerManager.Instance.SpawnAllPlayers(spawnPosition);

        uiHandler.HideAll();
        endCameraHolder.gameObject.SetActive(false);

        isCompleted = false;
        playTime = 0F;
        Debug.Log("Level \"" + levelName + "\" started.");
    }

    public void EndLevel()
    {
        //TODO: Say this game becomes co-op. Does it despawn everyone when only one player uses the Exit? Or does it wait for some, if not all, players?
        PlayerManager.Instance.DespawnAllPlayers();

        uiHandler.ShowAll();
        uiHandler.UpdateLevelResults(this);
        endCameraHolder.gameObject.SetActive(true);

        isCompleted = true;
        Debug.Log("Level \"" + levelName + "\" finished.");
    }

    //This one is called from the LevelUI
    public void ToNextLevel()
    {
        Debug.Log("ToNextLevel() was called");

        uiHandler.HideAll();
        endCameraHolder.gameObject.SetActive(false);

        GameManager gameManager = GameManager.Instance;
        gameManager.ToNextLevel();
    }

    public void ReportDeadEnemy(Character character)
    {
        killCount++;
    }

    public void ReportSecretFound(SecretAreaLevelEvent secretArea)
    {
        findingsCount++;
    }
}
