using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public partial class IntermissionManager : AbstractSingleton<IntermissionManager>
{
    [Header("Prefabs")]
    [SerializeField] private UIShopOffer uiShopOfferPrefab;

    [Header("Scene references")]
    [SerializeField] private SceneUI uiHandler;
    [SerializeField] private Transform offersHolder;

    public override void Awake()
    {
        base.Awake();
        
        //TODO: is it even necessary?
        //uiHandler.HideAll();
        Unhighlight(null);

        Debug.Log("IntermissionManager finished Awake()");
    }

    private void Start()
    {
        //TODO: all testing stuff goes here
        
        int qualityLevel = 2;
        GenerateOffers(qualityLevel);
        ShowOffers(offerList);
    }

    public void NextLevel()
    {
        uiHandler.HideAll();

        //TODO: Debug.Log("TODO THE ACTUAL SHOP OFFER BEING PUT INTO EFFECT");
        Debug.Log("TODO THE ACTUAL SHOP OFFER BEING PUT INTO EFFECT");

        GameManager gameManager = GameManager.Instance;
        gameManager.ToNextLevel();
    }

    public void QuitGame()
    {
        uiHandler.HideAll();

        GameManager gameManager = GameManager.Instance;
        gameManager.QuitGame();
    }
}
