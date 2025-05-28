using System;
using System.Collections.Generic;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class PlayerData
    {
        public int Money = 100;

        public List<SeedData> OwnedSeeds = new();
        public List<FruitData> Inventory = new();

        public List<string> FavoriteFruitIds = new(); // id фруктов, которые нельзя продать

        public List<PotUpgradeData> PotUpgrades = new();

        public List<string> SeenTutorialSteps = new(); // для туториала
    }
}