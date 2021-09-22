namespace WebAPI
{
    internal class WishItemFactory
    {
        public WishItem GetWishItem() => new();

        public WishItem GetWishItem(string name) => new(name);
    }
}
