using System;
using GrowAGarden.Scripts.Transfer.Enums;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class FruitData
    {
        public SeedData BasesSeedData;
        public string PlantType;
        public float Weight;
        public MutationType Modifier;
    }
}