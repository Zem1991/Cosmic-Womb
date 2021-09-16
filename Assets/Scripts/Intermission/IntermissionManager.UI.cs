using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public partial class IntermissionManager : AbstractSingleton<IntermissionManager>
{
    [Header("UI - Highlight")]
    [SerializeField] private Image highlightImage;
    [SerializeField] private Text highlightTitle;
    [SerializeField] private Text highlightDescription;
    [SerializeField] private UIShopOffer highlightedOffer;

    private void ClearOffers()
    {
        //TODO: Do I need a list of the generated UIShopOffers for easier handling? This seems to work good for now.
        UIShopOffer[] currentOffers = offersHolder.GetComponentsInChildren<UIShopOffer>();
        foreach (UIShopOffer forUISO in currentOffers)
        {
            Destroy(forUISO.gameObject);
        }
    }

    public void ShowOffers(List<ShopOffer> offers)
    {
        ClearOffers();

        foreach (ShopOffer forSO in offers)
        {
            UIShopOffer uiShopOffer = Instantiate(uiShopOfferPrefab, offersHolder);
            uiShopOffer.SetShopOffer(forSO);
        }
    }

    public void Highlight(UIShopOffer uiShopOffer)
    {
        if (!uiShopOffer)
        {
            Unhighlight(null);
            return;
        }

        highlightedOffer = uiShopOffer;

        ShopOffer shopOffer = uiShopOffer.GetShopOffer();
        highlightImage.gameObject.SetActive(true);
        highlightImage.sprite = shopOffer.GetSprite();
        highlightTitle.text = shopOffer.GetTitle();
        highlightDescription.text = shopOffer.GetDescription();
    }
    
    public void Unhighlight(UIShopOffer uiShopOffer)
    {
        if (uiShopOffer == null || uiShopOffer == highlightedOffer)
        {
            highlightedOffer = null;

            highlightImage.gameObject.SetActive(false);
            highlightImage.sprite = null;
            highlightTitle.text = null;
            highlightDescription.text = "Hover one of the options to see more about it." + "\nClick to select/deselect it.";
        }
    }
    
    public void Select(UIShopOffer uiShopOffer)
    {
        ShopOffer shopOffer = uiShopOffer.GetShopOffer();
        if (selectionList.Contains(shopOffer))
            selectionList.Remove(shopOffer);
        else
            selectionList.Add(shopOffer);

        if (selectionList.Count > selectionAmount)
            selectionList.RemoveAt(0);
    }
}
