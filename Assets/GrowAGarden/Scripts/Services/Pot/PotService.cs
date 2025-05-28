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

        public PotService(PotConfig config)
        {
            _config = config;

            /*for (int i = 0; i < config.InitialPotCount; i++)
            {
                _potSlots.Add(new PotSlot(config));
            }*/
        }

        public void Tick()
        {
            foreach (var slot in _potSlots)
            {
                slot.Tick();
            }
        }

        public void AddPot(PotSlot pot) => _potSlots.Add(pot);
        
        public bool TryPlantSeed(SeedData seed)
        {
            var empty = _potSlots.FirstOrDefault(p => !p.HasPlant);
            if (empty == null) return false;

            empty.Plant(seed);
            return true;
        }

        public List<FruitItem> HarvestAll()
        {
            var harvested = new List<FruitItem>();

            foreach (var slot in _potSlots)
            {
                if (slot.IsReady)
                {
                    var fruit = slot.Harvest();
                    harvested.Add(fruit);
                }
            }

            return harvested;
        }
    }
}