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

    public List<ShopOffer> SelectOffers(System.Random rng, int qualityLevel, int amountRequired)
    {
        List<ShopOffer> result = new List<ShopOffer>();

        List<PossibleShopOffer> possibleShopOfferList = GetPossibleOffers(qualityLevel);
        if (possibleShopOfferList.Count >= 2)
        {
            int totalWeight = 0;
            foreach (PossibleShopOffer forPSO in possibleShopOfferList)
            {
                totalWeight += forPSO.Weight;
            }

            for (int i = 0; i < amountRequired; i++)
            {
                ShopOffer shopOffer = SelectOffer(rng, possibleShopOfferList, totalWeight);
                result.Add(shopOffer);
            }
        }
        else if (possibleShopOfferList.Count == 1)
        {
            PossibleShopOffer selectedOffer = possibleShopOfferList[0];
            result.Add(selectedOffer.ShopOffer);
        }
        return result;
    }
    
    private ShopOffer SelectOffer(System.Random rng, List<PossibleShopOffer> possibleShopOfferList, int totalWeight)
    {
        int randomNumber = rng.Next(0, totalWeight);
        ShopOffer result = null;
        foreach (PossibleShopOffer forPSO in possibleShopOfferList)
        {
            int forPSOWeight = forPSO.Weight;
            if (randomNumber < forPSOWeight)
            {
                result = forPSO.ShopOffer;
                break;
            }
            randomNumber -= forPSOWeight;
        }
        return result;
    }
}
