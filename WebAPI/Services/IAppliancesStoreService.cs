using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IAppliancesStoreService
    {
        Task Add(string name, double price);
        Task<List<ShopItem>> GetItems();
        Task Update(string name, double price);
        Task Delete(string name);
    }
}