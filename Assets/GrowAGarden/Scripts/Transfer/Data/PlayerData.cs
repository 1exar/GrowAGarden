using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class PlayerData
    {
        [FormerlySerializedAs("Money")] public int money = 100;

        [FormerlySerializedAs("OwnedSeeds")] public List<SeedData> ownedSeeds = new();
        [FormerlySerializedAs("Inventory")] public List<FruitData> inventory = new();

        [FormerlySerializedAs("FavoriteFruitIds")] public List<string> favoriteFruitIds = new(); // id фруктов, которые нельзя продать

        [FormerlySerializedAs("SeenTutorialSteps")] public List<string> seenTutorialSteps = new(); // для туториала
    }
}