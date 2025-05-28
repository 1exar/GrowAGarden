using System;
using GrowAGarden.Scripts.Transfer.Enums;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class FruitData
    {
        public string Id; // уникальный GUID
        public string PlantType;
        public float Weight;
        public FruitModifier Modifier; // обычный / золотой / радужный
    }
}