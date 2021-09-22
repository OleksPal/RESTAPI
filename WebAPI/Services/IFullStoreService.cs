using System.Collections.Generic;

namespace WebAPI
{
    public interface IFullStoreService
    {
        List<ShopItem> GetAll();
    }
}