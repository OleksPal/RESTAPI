using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public class FullStoreService : IFullStoreService
    {
        FoodStoreRepository fsr = new();
        AppliancesStoreRepository asr = new();

        public async Task<List<ShopItem>> GetAll()
        {
            List<ShopItem> answer = new();

            answer.AddRange(await asr.GetItems());
            answer.AddRange(await fsr.GetItems());
            return answer;
        }
    }
}