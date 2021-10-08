using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IStoreService
    {
        Task Add(string name, double price);
        Task<List<ShopItem>> GetItems();
        Task<List<ShopItem>> GetItems(string name);
        Task Update(string name, double price);
        Task Delete(string name);
    }
}