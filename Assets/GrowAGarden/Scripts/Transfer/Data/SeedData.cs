using System;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "NewSeedData", menuName = "Game/SeedData")]
    public class SeedData : ScriptableObject
    {
        public string seedName;
        public Sprite icon;
        public int basePrice;

        public Rarity rarityLevel;
        public int growDuration;
    }
}