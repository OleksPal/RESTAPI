using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IFullStoreService
    {
        Task<List<ShopItem>> AllItems { get; }
    }
}