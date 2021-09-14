using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopPool : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool ignoreAvailability;

    [Header("Contents")]
    [SerializeField] private List<ShopOffer> shopOfferList = new List<ShopOffer>();

    public List<PossibleShopOffer> GetPossibleOffers(int qualityLevelLimit)
    {
        List<PossibleShopOffer> result = new List<PossibleShopOffer>();
        foreach (ShopOffer forSO in shopOfferList)
        {
            int offerQualityLevel = forSO.GetQualityLevel();
            if (offerQualityLevel > qualityLevelLimit) continue;

            int offerWeight = ignoreAvailability ? forSO.GetWeight() : forSO.CalculateAvailability();
            if (offerWeight <= 0) continue;

            PossibleShopOffer possibleShopOffer = new PossibleShopOffer(forSO, offerWeight);
            result.Add(possibleShopOffer);
        }
        return result;
    }

    public List<ShopOffer> SelectOffers(System.Random rng, int qualityLevelLimit, int amountRequired)
    {
        List<ShopOffer> result = new List<ShopOffer>();

        List<PossibleShopOffer> possibleShopOfferList = GetPossibleOffers(qualityLevelLimit);
        if (possibleShopOfferList.Count >= 2)
        {
            int allWeights = 0;
            foreach (PossibleShopOffer forPSO in possibleShopOfferList)
            {
                allWeights += forPSO.Weight;
            }

            for (int i = 0; i < amountRequired; i++)
            {
                double rngValue = allWeights * rng.NextDouble();
                PossibleShopOffer selectedOffer = possibleShopOfferList.Last(shopOffer => shopOffer.Weight <= rngValue);
                result.Add(selectedOffer.ShopOffer);
            }
        }
        else if (possibleShopOfferList.Count == 1)
        {
            PossibleShopOffer selectedOffer = possibleShopOfferList[0];
            result.Add(selectedOffer.ShopOffer);
        }
        return result;
    }
}
