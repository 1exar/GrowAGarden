using System;
using System.Collections.Generic;
using System.Linq;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Services.SeedShop
{
    public class SeedShopService : ITickable, IDisposable
    {
        private readonly List<SeedData> _allSeeds;
        private readonly SeedShopConfig _config;

        private float _timeSinceLastRefresh = 0f;

        private List<SeedData> _currentShopSeeds = new List<SeedData>();

        public event Action OnShopUpdated;

        public SeedShopService(List<SeedData> allSeeds, SeedShopConfig config)
        {
            _allSeeds = allSeeds ?? throw new ArgumentNullException(nameof(allSeeds));
            _config = config ?? throw new ArgumentNullException(nameof(config));

            RefreshShop();
        }

        public IReadOnlyList<SeedData> CurrentShopSeeds => _currentShopSeeds;

        public void Tick()
        {
            _timeSinceLastRefresh += Time.deltaTime;
            if (_timeSinceLastRefresh >= _config.shopRefreshIntervalSeconds)
            {
                RefreshShop();
                _timeSinceLastRefresh = 0f;
            }
        }

        private void RefreshShop()
        {
            _currentShopSeeds.Clear();

            var rarityWeightDict = _config.rarityWeights.ToDictionary(rw => rw.rarity, rw => rw.weight);
            
            int shopSize = _config.shopSize;
            for (int i = 0; i < shopSize; i++)
            {
                var seed = GetRandomSeedByRarityWeight(rarityWeightDict);
                if (seed != null)
                {
                    _currentShopSeeds.Add(seed);
                }
            }

            OnShopUpdated?.Invoke();
            Debug.Log("SeedShop refreshed: " + string.Join(", ", _currentShopSeeds.Select(s => s.SeedName)));
        }

        private SeedData GetRandomSeedByRarityWeight(Dictionary<Rarity, float> rarityWeights)
        {
            var filteredSeeds = _allSeeds.Where(s => rarityWeights.ContainsKey(s.RarityLevel)).ToList();
            if (filteredSeeds.Count == 0) return null;

            float totalWeight = filteredSeeds.Sum(s => rarityWeights[s.RarityLevel]);

            float randomValue = UnityEngine.Random.Range(0f, totalWeight);
            float cumulative = 0f;

            foreach (var seed in filteredSeeds)
            {
                cumulative += rarityWeights[seed.RarityLevel];
                if (randomValue <= cumulative)
                {
                    return seed;
                }
            }

            return filteredSeeds.Last();
        }

        public void Dispose()
        {
            OnShopUpdated = null;
        }
    }
}