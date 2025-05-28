using GrowAGarden.Scripts.Services.SeedShop;
using Zenject;

namespace GrowAGarden.Scripts.Services.GameLoop
{
    public class GameLoopService : ITickable
    {
        private readonly SeedShopService _seedShopService;
    
        public GameLoopService(SeedShopService seedShopService)
        {
            _seedShopService = seedShopService;
        }

        public void Tick()
        {
            _seedShopService.Tick();
        }
    }
}