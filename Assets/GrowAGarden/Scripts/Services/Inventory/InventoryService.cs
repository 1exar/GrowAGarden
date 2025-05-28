using System;
using System.Collections.Generic;
using GrowAGarden.Scripts.Transfer.Items;

namespace GrowAGarden.Scripts.Services.Inventory
{
    public class InventoryService
    {
        public event Action OnInventoryChanged;

        private readonly List<SeedItem> _seeds = new();
        private readonly List<FruitItem> _fruits = new();

        public IReadOnlyList<SeedItem> GetSeeds() => _seeds;
        public IReadOnlyList<FruitItem> GetFruits() => _fruits;

        public void AddSeed(SeedItem seed)
        {
            _seeds.Add(seed);
            OnInventoryChanged?.Invoke();
        }
        
        public void RemoveSeed(SeedItem seed)
        {
            if(seed.RemoveQuantity(1) == false) _seeds.Remove(seed);
            OnInventoryChanged?.Invoke();
        }

        public void AddFruit(FruitItem fruit)
        {
            _fruits.Add(fruit);
            OnInventoryChanged?.Invoke();
        }

        public void RemoveFruit(FruitItem fruit)
        {
            _fruits.Remove(fruit);
            OnInventoryChanged?.Invoke();
        }

        public void Clear()
        {
            _seeds.Clear();
            _fruits.Clear();
            OnInventoryChanged?.Invoke();
        }
    }
}