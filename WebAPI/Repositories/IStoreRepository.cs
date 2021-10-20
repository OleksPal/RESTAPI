using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IStoreRepository
    {
        Task AddItem(string name, double price);
        Task<ShopItem> GetItemsByName(string name);
        Task UpdateItemInTable(string name, double price);
        Task DeleteItemFromTable(string name);

        List<ShopItem> ItemList { get; }
    }
}