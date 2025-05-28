using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Enums;
using GrowAGarden.Scripts.Transfer.Items;
using UnityEngine;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotSlot
    {
        private readonly PotConfig _config;

        private float _growthTime;
        private SeedData _currentSeed;

        public bool HasPlant => _currentSeed != null;
        public bool IsReady => HasPlant && _growthTime >= _currentSeed.GrowDuration;

        public PotSlot(PotConfig config)
        {
            _config = config;
        }

        public void Plant(SeedData seed)
        {
            _currentSeed = seed;
            _growthTime = 0f;
        }

        public void Tick()
        {
            if (!HasPlant || IsReady)
                return;

            _growthTime += Time.deltaTime * _config.GrowthSpeedMultiplier;
        }

        public FruitItem Harvest()
        {
            if (!IsReady) return null;

            var result = new FruitItem(_currentSeed, RollMutation());
            _currentSeed = null;
            _growthTime = 0f;
            return result;
        }

        private MutationType RollMutation()
        {
            float roll = UnityEngine.Random.value;
            if (roll < _config.MutationChance)
                return MutationType.Golden;

            return MutationType.Normal;
        }
    }
}