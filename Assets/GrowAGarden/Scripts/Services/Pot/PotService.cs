using System.Collections.Generic;
using GrowAGarden.Scripts.Services.PlayerData;
using GrowAGarden.Scripts.Transfer.Config;
using Zenject;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotService
    {
        private readonly List<PotSlot> _potSlots = new();
        private readonly PotConfig _config;

        [Inject] private IPlayerDataService _playerDataService;
        
        public IReadOnlyList<PotSlot> PotSlots => _potSlots;

        public PotService(PotConfig config, List<PotView> potSlots)
        {
            _config = config;

            potSlots.ForEach(view =>
            {
                PotSlot slot = new PotSlot(_config, _playerDataService);
                _potSlots.Add(slot);
                view.SetPotSlot(slot);
            });
        }

        public void Tick()
        {
            foreach (var slot in _potSlots)
            {
                slot.Tick();
            }
        }

        public void HarvestAll()
        {
            foreach (var slot in _potSlots)
            {
                if (slot.IsReady)
                {
                    slot.Harvest();
                }
            }
        }
    }
}