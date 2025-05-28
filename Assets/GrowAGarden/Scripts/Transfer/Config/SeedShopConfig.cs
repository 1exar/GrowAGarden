using System.Collections.Generic;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;

namespace GrowAGarden.Scripts.Transfer.Config
{
    [CreateAssetMenu(fileName = "SeedShopConfig", menuName = "Game/SeedShopConfig")]
    public class SeedShopConfig : ScriptableObject
    {
        public float shopRefreshIntervalSeconds = 300f; // 5 минут
        public int shopSize;

        [System.Serializable]
        public struct RarityWeight
        {
            public Rarity rarity;
            [Range(0f, 1f)] public float weight;
        }

        public List<RarityWeight> rarityWeights;
    }
}