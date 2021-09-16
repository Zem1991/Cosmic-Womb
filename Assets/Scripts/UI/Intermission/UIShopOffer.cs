using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIShopOffer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Self references")]
    [SerializeField] private Image frame;
    [SerializeField] private Image image;
    [SerializeField] private Button button;

    [Header("Shop Offer")]
    [SerializeField] private ShopOffer shopOffer;

    #region Shop Offer
    public ShopOffer GetShopOffer()
    {
        return shopOffer;
    }
    public void SetShopOffer(ShopOffer shopOffer)
    {
        //TODO: more UI stuff
        this.shopOffer = shopOffer;
    }
    #endregion

    public void OnPointerEnter(PointerEventData eventData)
    {
        IntermissionManager intermissionManager = IntermissionManager.Instance;
        intermissionManager.Highlight(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IntermissionManager intermissionManager = IntermissionManager.Instance;
        intermissionManager.Unhighlight(this);
    }

    public void Click()
    {
        IntermissionManager intermissionManager = IntermissionManager.Instance;
        intermissionManager.Select(this);
    }
}
