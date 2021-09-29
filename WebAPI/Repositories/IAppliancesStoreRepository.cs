using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IAppliancesStoreRepository
    {
        Task AddItem(string name, double price);
        Task<List<ShopItem>> GetItems();
        Task UpdateItemInTable(string name, double price);
        Task DeleteItemFromTable(string name);
    }
}