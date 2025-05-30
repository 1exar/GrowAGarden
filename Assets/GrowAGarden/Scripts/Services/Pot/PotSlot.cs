using GrowAGarden.Scripts.Services.PlayerData;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Enums;
using GrowAGarden.Scripts.Transfer.Items;
using UnityEngine;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotSlot
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly PotConfig _config;

        private float _growthTime;
        private SeedData _currentSeed;

        public bool HasPlant => _currentSeed != null;
        public bool IsReady => HasPlant && _growthTime >= _currentSeed.growDuration;

        public PotSlot(PotConfig config, IPlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
            _config = config;
        }

        public bool Plant(SeedData seed)
        {
            if(HasPlant) return false;
            _currentSeed = seed;
            _growthTime = 0f;
            return true;
        }

        public void Tick()
        {
            if (!HasPlant || IsReady)
                return;

            _growthTime += Time.deltaTime * _config.growthSpeedMultiplier;
        }

        public void Harvest()
        {
            if (!IsReady) return;

            var result = new FruitItem(_currentSeed, RollMutation());
            _growthTime = 0f;
            _playerDataService.AddFruit(result);
        }

        public void RemoveSeed()
        {
            _currentSeed = null;
            _growthTime = 0f;
        }

        private MutationType RollMutation()
        {
            float roll = UnityEngine.Random.value;
            if (roll < _config.mutationChance)
                return MutationType.Golden;

            return MutationType.Normal;
        }
    }
}