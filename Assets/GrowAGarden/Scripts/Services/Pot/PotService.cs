using System.Collections.Generic;
using System.Linq;
using GrowAGarden.Scripts.Services.Inventory;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotService
    {
        private readonly List<PotSlot> _potSlots = new();
        private readonly PotConfig _config;

        public IReadOnlyList<PotSlot> PotSlots => _potSlots;

        public PotService(PotConfig config, List<PotView> potSlots, InventoryService inventoryService)
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