public struct PossibleShopOffer
{
    private ShopOffer shopOffer;
    private int weight;

    public PossibleShopOffer(ShopOffer shopOffer, int aweight)
    {
        this.shopOffer = shopOffer;
        this.weight = aweight;
    }

    public ShopOffer ShopOffer { get => shopOffer; }
    public int Weight { get => weight; }
}