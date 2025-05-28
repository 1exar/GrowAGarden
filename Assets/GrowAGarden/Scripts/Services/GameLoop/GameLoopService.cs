using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Services.SeedShop;
using Zenject;

namespace GrowAGarden.Scripts.Services.GameLoop
{
    public class GameLoopService : ITickable
    {
        private readonly SeedShopService _seedShopService;
        private readonly PotService _potService;
    
        public GameLoopService(SeedShopService seedShopService, PotService potService)
        {
            _seedShopService = seedShopService;
            _potService = potService;
        }

        public void Tick()
        {
            _seedShopService.Tick();
            _potService.Tick();
        }
    }
}