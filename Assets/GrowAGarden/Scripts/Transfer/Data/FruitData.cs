using System;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class FruitData
    {
        public SeedData BasesSeedData;
        public Sprite Icon;
        public float Weight;
        public MutationType Modifier;
    }
}