using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel_LevelResults : MonoBehaviour
{
    [Header("Level identification")]
    [SerializeField] private Text levelNameText;

    [Header("Time")]
    [SerializeField] private Text playTimeText;
    [SerializeField] private Text completionTimeText;

    [Header("Kills")]
    [SerializeField] private Text killCountText;
    [SerializeField] private Text enemyCountText;

    [Header("Secrets")]
    [SerializeField] private Text findingsCountText;
    [SerializeField] private Text secretsCountText;

    public void ManualUpdate(LevelController levelController)
    {
        //TODO: send this timeFormat to somewhere more global
        string timeFormat = @"mm\:ss\.fff";

        string levelName = levelController.GetLevelName();

        float playTime = levelController.GetPlayTime();
        string playTimeString = TimeSpan.FromSeconds(playTime).ToString(timeFormat);
        float completionTime = levelController.GetCompletionTime();
        string completionTimeString = TimeSpan.FromSeconds(completionTime).ToString(timeFormat);

        int killCount = levelController.GetKillCount();
        string killCountString = killCount.ToString();
        int enemyCount = levelController.GetEnemyCount();
        string enemyCountString = enemyCount.ToString();

        int findingsCount = levelController.GetFindingsCount();
        string findingsCountString = findingsCount.ToString();
        int secretsCount = levelController.GetSecretsCount();
        string secretsCountString = secretsCount.ToString();

        levelNameText.text = levelName;

        playTimeText.text = playTimeString;
        completionTimeText.text = completionTimeString;

        killCountText.text = killCountString;
        enemyCountText.text = enemyCountString;

        findingsCountText.text = findingsCountString;
        secretsCountText.text = secretsCountString;
    }
}
