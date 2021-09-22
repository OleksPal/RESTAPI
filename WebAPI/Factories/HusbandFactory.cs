using System.Collections.Generic;

namespace WebAPI
{
    internal class HusbandFactory
    {
        public Husband GetHusband() => new();

        public Husband GetHusband(List<WishItem> wishList) => new(wishList);
    }
}