using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneOperations : MonoBehaviour
{
    public bool CheckIntermission()
    {
        sceneIntermission = SceneManager.GetSceneByName(SCENE_INTERMISSION);
        sceneIntermissionHandle = sceneIntermission.handle;
        return sceneIntermissionHandle != 0;
    }
    
    public AsyncOperation UnloadIntermission()
    {
        if (!CheckIntermission()) return null;
        return UnloadSceneAsync(SCENE_INTERMISSION);
    }
    
    public AsyncOperation LoadIntermission()
    {
        if (CheckIntermission()) return null;
        return LoadSceneAsync(SCENE_INTERMISSION);
    }
}
