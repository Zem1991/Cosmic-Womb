using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : AbstractSingleton<LevelController>
{
    [Header("Level data")]
    [SerializeField] private string levelName = "Unnamed level";
    [SerializeField] private bool isCompleted = false;
    [SerializeField] private float completionTime = 30F;
    [SerializeField] private float playTime = 0F;

    private void Start()
    {
        StartLevel();
    }

    private void Update()
    {
        if (!isCompleted)
        {
            playTime += Time.deltaTime;
        }
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
