using System.Collections.Generic;

namespace WebAPI
{
    internal class AppliancesStoreFactory
    {
        public AppliancesStore GetAppliancesStore()
            => new();

        public AppliancesStore GetAppliancesStore(List<ShopItem> items)
            => new(items);
    }
}
