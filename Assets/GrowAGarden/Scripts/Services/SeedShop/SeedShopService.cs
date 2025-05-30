using System;
using System.Collections.Generic;
using System.Linq;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;

namespace GrowAGarden.Scripts.Services.SeedShop
{
    public class SeedShopService : IDisposable
    {
        private readonly List<SeedData> _allSeeds;
        private readonly SeedShopConfig _config;

        private float _timeSinceLastRefresh;

        private List<SeedData> _currentShopSeeds = new();
        public float RemainingTime { get; private set; }
        public event Action OnShopUpdated;

        public SeedShopService(List<SeedData> allSeeds, SeedShopConfig config)
        {
            _allSeeds = allSeeds ?? throw new ArgumentNullException(nameof(allSeeds));
            _config = config ?? throw new ArgumentNullException(nameof(config));

            RefreshShop();
        }

        public List<SeedData> CurrentShopSeeds => _currentShopSeeds;

        public void Tick()
        {
            _timeSinceLastRefresh += Time.deltaTime;

            RemainingTime = _config.shopRefreshIntervalSeconds - _timeSinceLastRefresh;
            RemainingTime = Mathf.Max(RemainingTime, 0f);

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
            var availableSeeds = new List<SeedData>(_allSeeds);

            var selectedSeedNames = new HashSet<string>();

            for (int i = 0; i < shopSize; i++)
            {
                var seed = GetRandomUniqueSeedByRarityWeight(rarityWeightDict, availableSeeds, selectedSeedNames);
                if (seed != null)
                {
                    _currentShopSeeds.Add(seed);
                    selectedSeedNames.Add(seed.seedName);

                   
                    availableSeeds.RemoveAll(s => s.seedName == seed.seedName);
                }
                else
                {
                    break;
                }
            }

            OnShopUpdated?.Invoke();
            Debug.Log("SeedShop refreshed: " + string.Join(", ", _currentShopSeeds.Select(s => s.seedName)));
        }

        private SeedData GetRandomUniqueSeedByRarityWeight(
            Dictionary<Rarity, float> rarityWeights,
            List<SeedData> availableSeeds,
            HashSet<string> selectedNames)
        {
            var filteredSeeds = availableSeeds
                .Where(s => rarityWeights.ContainsKey(s.rarityLevel) && !selectedNames.Contains(s.seedName))
                .ToList();

            if (filteredSeeds.Count == 0) return null;

            float totalWeight = filteredSeeds.Sum(s => rarityWeights[s.rarityLevel]);
            float randomValue = UnityEngine.Random.Range(0f, totalWeight);
            float cumulative = 0f;

            foreach (var seed in filteredSeeds)
            {
                cumulative += rarityWeights[seed.rarityLevel];
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