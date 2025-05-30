using System;
using System.Collections.Generic;
using System.Linq;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Enums;
using GrowAGarden.Scripts.Transfer.Items;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Services.PlayerData
{
    public class PlayerDataService : IPlayerDataService, IInitializable
    {
        private Transfer.Data.PlayerData _playerData;

        private Action _onDataChanged;
        public Action OnDataChandeg() => _onDataChanged;

        public Transfer.Data.PlayerData Get() => _playerData;
        
        private bool IsDataContainsItem<T>(List<T> data, string itemName, out T existedItem) where T : BaseItem
        {
            var item = data.Where(s => s.itemName == itemName);
            existedItem = item.First();
            return item.Any();
        }
        
        public void AddFruit(FruitItem fruit)
        {
            _playerData.fruitsInInventory.Add(fruit);
            Save();
        }

        public void RemoveFruit(FruitItem fruit)
        {
            _playerData.fruitsInInventory.Remove(fruit);
            Save();
        }

        public void AddSeed(SeedData seed)
        {
            if (IsDataContainsItem(_playerData.seedsInInventory,seed.seedName, out SeedItem existingSeed))
            {
                existingSeed.AddQuantity(1);
            }
            else
            {
                SeedItem item = new SeedItem(seed, 1);
                _playerData.seedsInInventory.Add(item);
            }
            
            Save();
        }

        public void RemoveSeed(SeedData seed)
        {
            if (IsDataContainsItem(_playerData.seedsInInventory,seed.seedName, out SeedItem existingSeed))
            {
                existingSeed.RemoveQuantity(1);
            }
            else
            {
                Debug.LogError("Try to remove unexisted seed");
            }
            
            Save();
        }

        public bool TrySpendMoney(int money)
        {
            if (_playerData.money < money)
            {
                return false;
            }
            else
            {
                _playerData.money -= money;
                Save();
                return true;
            }
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey("save"))
            {
                _playerData = JsonUtility.FromJson<Transfer.Data.PlayerData>("save");
            }
            else
            {
                _playerData = new Transfer.Data.PlayerData();
            }
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(_playerData);
            PlayerPrefs.SetString("save", json);
            _onDataChanged?.Invoke();
        }

        public void Initialize()
        { 
            Load();   
        }
    }
}