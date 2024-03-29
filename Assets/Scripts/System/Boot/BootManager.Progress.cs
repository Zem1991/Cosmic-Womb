using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BootManager : AbstractSingleton<BootManager>
{
    private Action onFinish;

    [Header("Progress")]
    [SerializeField] private bool isLoading;
    [SerializeField] private int loadPercent;
    [SerializeField] private string processName;
    [SerializeField] private List<AsyncOperation> asyncOperationList = new List<AsyncOperation>();
    
    private void StartLoading(string processName, List<AsyncOperation> aoList, Action onFinish)
    {
        this.onFinish = onFinish;

        isLoading = true;
        loadPercent = 0;
        this.processName = processName;
        asyncOperationList = new List<AsyncOperation>(aoList);

        uiHandler.ShowAll();
        Debug.Log("Process \"" + processName + "\" started.");
    }

    private void UpdateLoading()
    {
        if (!isLoading) return;

        if (loadPercent < 100)
        {
            float lowestProgress = 100F;
            foreach (AsyncOperation forAO in asyncOperationList)
            {
                float forAOProgress = forAO.progress * 100;
                lowestProgress = Mathf.Min(lowestProgress, forAOProgress);

                //Check if the load has finished. If true, then the activation happens next.
                if (forAOProgress >= 90f)
                {
                    forAO.allowSceneActivation = true;
                }
            }

            //TODO: show the average value of each operation progress, instead of just the smaller one.

            loadPercent = (int)lowestProgress;
            uiHandler.UpdateBootProgress(loadPercent);
            Debug.Log("Process \"" + processName + "\" at " + loadPercent + "%.");
        }
        else
        {
            FinishLoading();
        }
    }

    private void FinishLoading()
    {
        uiHandler.HideAll();
        Debug.Log("Process \"" + processName + "\" finished.");

        isLoading = false;
        loadPercent = 0;
        processName = null;
        asyncOperationList.Clear();

        onFinish?.Invoke();
        //For some reason I can't clear the 'onFinish' variable. If I try, it risks messing with another process's onFinish action.
        //onFinish = null;
    }
}
