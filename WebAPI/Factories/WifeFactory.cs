using System.Collections.Generic;

namespace WebAPI
{
    internal class WifeFactory
    {
        public Wife GetWife() => new();

        public Wife GetWife(List<WishItem> wishList) => new(wishList);
    }
}
