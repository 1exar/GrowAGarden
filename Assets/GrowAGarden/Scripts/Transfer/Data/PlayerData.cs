using System;
using System.Collections.Generic;
using GrowAGarden.Scripts.Transfer.Items;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class PlayerData
    {
        public int money = 20;
        public List<SeedItem> seedsInInventory = new();
        public List<FruitItem> fruitsInInventory = new();
    }
}