using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IGetFoodStoreItemList 
    {
        List<ShopItem> FoodStoreItemList { get; }
    }

    public interface IGetAppliancesStoreItemList
    {
        List<ShopItem> AppliancesStoreItemList { get; }
    }
}