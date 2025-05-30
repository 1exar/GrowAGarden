using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Items;

namespace GrowAGarden.Scripts.Services.PlayerData
{
    public interface IPlayerDataService
    {

        void AddFruit(FruitItem fruitData);
        void RemoveFruit(FruitItem fruitData);
        void AddSeed(SeedData seed);
        void RemoveSeed(SeedData seed);
        bool TrySpendMoney(int money);
        void Save();
        Transfer.Data.PlayerData Get();
    }
}