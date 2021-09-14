using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Pools")]
    [SerializeField] private ShopPool normalPool;
    [SerializeField] private ShopPool exaustionPool;
    //[SerializeField] private ShopPool timePool;
    //[SerializeField] private ShopPool killsPool;
    //[SerializeField] private ShopPool secretsPool;

    [Header("Offers")]
    [SerializeField] private int offerAmount = 4;
    [SerializeField] private List<ShopOffer> shopOfferList = new List<ShopOffer>();

    [Header("Choices")]
    [SerializeField] private int choiceAmount = 1;
    
    #region Offers
    public int GetOfferAmount()
    {
        return offerAmount;
    }
    public List<ShopOffer> GetShopOfferList()
    {
        return shopOfferList;
    }
    #endregion

    #region Choices
    public int GetChoiceAmount()
    {
        return choiceAmount;
    }
    #endregion

    public void GenerateShopOfferList(int qualityLevelLimit)
    {
        //TODO: seeded runs myabe?
        System.Random rng = new System.Random();
        int amount = offerAmount;
        
        List<ShopOffer> fromNormalPool = normalPool.SelectOffers(rng, qualityLevelLimit, amount);
        amount -= fromNormalPool.Count;

        List<ShopOffer> fromExaustionPool = exaustionPool.SelectOffers(rng, qualityLevelLimit, amount);
        amount -= fromNormalPool.Count;

        shopOfferList = new List<ShopOffer>();
        shopOfferList.AddRange(fromNormalPool);
        shopOfferList.AddRange(fromExaustionPool);
        shopOfferList = shopOfferList.OrderBy(item => rng.Next()).ToList();
    }

    public void MarkOffered()
    {
        foreach (ShopOffer forSO in shopOfferList)
        {
            forSO.SetOffered(true);
        }
    }

    public void MarkChosen(ShopOffer shopOffer)
    {
        shopOffer.SetChosen(true);
    }
}
