using System;
using GrowAGarden.Scripts.Transfer.Enums;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class SeedData
    {
        public string Id; // уникальный идентификатор
        public string PlantType; // например "Strawberry"
        public Rarity Rarity;
        public int Quantity;
    }
}