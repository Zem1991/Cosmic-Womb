using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : AbstractSingleton<LevelController>
{
    [Header("Level information")]
    [SerializeField] private string levelName = "Unnamed level";
    [SerializeField] private float completionTime = 30F;
    [SerializeField] private LevelSpawnPosition spawnPosition;

    [Header("Level data")]
    [SerializeField] private bool isCompleted = false;
    [SerializeField] private float playTime = 0F;

    private void Start()
    {
        //TODO: is this supposed to be called here or within GameManager?
        StartLevel();
    }

    private void Update()
    {
        if (!isCompleted)
        {
            playTime += Time.deltaTime;
        }
    }

    public LevelSpawnPosition GetSpawnPosition()
    {
        return spawnPosition;
    }

    public void StartLevel()
    {
        isCompleted = false;
        playTime = 0F;
    }

    public void EndLevel()
    {
        isCompleted = true;
        Debug.Log("Level completed in " + playTime  + " seconds.");
        Debug.Log(playTime + " / " + completionTime);
        GameManager.Instance.LoadNextLevel();
    }
}
