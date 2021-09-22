namespace WebAPI
{
    internal class ShopItemFactory
    {
        public ShopItem GetShopItem() => new();

        public ShopItem GetShopItem(string name, double price)
            => new(name, price);
    }
}