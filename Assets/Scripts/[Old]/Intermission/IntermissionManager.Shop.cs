using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public partial class IntermissionManager : AbstractSingleton<IntermissionManager>
{
    [Header("Shop Pools")]
    [SerializeField] private ShopPool normalPool;
    [SerializeField] private ShopPool exaustionPool;
    //[SerializeField] private ShopPool timePool;
    //[SerializeField] private ShopPool killsPool;
    //[SerializeField] private ShopPool secretsPool;

    [Header("Shop Offers")]
    [SerializeField] private int offerAmount = 4;
    [SerializeField] private List<ShopOffer> offerList = new List<ShopOffer>();

    [Header("Shop Selections")]
    [SerializeField] private int selectionAmount = 1;
    [SerializeField] private List<ShopOffer> selectionList = new List<ShopOffer>();
    
    #region Offers
    public int GetOfferAmount()
    {
        return offerAmount;
    }
    public List<ShopOffer> GetShopOfferList()
    {
        return offerList;
    }
    #endregion

    #region Selection
    public int GetSelectionAmount()
    {
        return selectionAmount;
    }
    public List<ShopOffer> GetSelectionList()
    {
        return selectionList;
    }
    #endregion

    public void GenerateOffers(int qualityLevel, bool markOffered = true)
    {
        //TODO: seeded runs myabe?
        System.Random rng = new System.Random();
        int amount = offerAmount;
        
        List<ShopOffer> fromNormalPool = normalPool.SelectOffers(rng, qualityLevel, amount);
        amount -= fromNormalPool.Count;

        List<ShopOffer> fromExaustionPool = exaustionPool.SelectOffers(rng, qualityLevel, amount);
        amount -= fromNormalPool.Count;

        offerList = new List<ShopOffer>();
        offerList.AddRange(fromNormalPool);
        offerList.AddRange(fromExaustionPool);
        offerList = offerList.OrderBy(item => rng.Next()).ToList();

        if (markOffered) MarkOffered();
    }

    private void MarkOffered()
    {
        foreach (ShopOffer forSO in offerList)
        {
            forSO.SetOffered(true);
        }
    }

    public void MarkChosen(ShopOffer shopOffer)
    {
        shopOffer.SetChosen(true);
    }
}
