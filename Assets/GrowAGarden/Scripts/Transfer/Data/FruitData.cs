using System;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class FruitData
    {
        public SeedData basesSeedData;
        public Sprite icon;
        public float weight;
        public MutationType modifier;
    }
}