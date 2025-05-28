using System.Collections.Generic;
using System.Linq;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Items;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotService
    {
        private readonly List<PotSlot> _potSlots = new();
        private readonly PotConfig _config;

        public IReadOnlyList<PotSlot> PotSlots => _potSlots;

        public PotService(PotConfig config, List<PotView> potSlots, InventoryService.InventoryService inventoryService)
        {
            _config = config;

            potSlots.ForEach(view =>
            {
                PotSlot slot = new PotSlot(_config, inventoryService);
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

        public bool TryPlantSeed(SeedData seed)
        {
            var empty = _potSlots.FirstOrDefault(p => !p.HasPlant);
            if (empty == null) return false;

            empty.Plant(seed);
            return true;
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