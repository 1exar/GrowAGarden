using System;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "NewSeedData", menuName = "Game/SeedData")]
    public class SeedData : ScriptableObject
    {
        public string SeedName;
        public Sprite Icon;
        public int BasePrice;

        public Rarity RarityLevel;
    }
}