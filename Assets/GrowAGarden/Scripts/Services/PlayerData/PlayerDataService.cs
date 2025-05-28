using System.IO;
using Cysharp.Threading.Tasks;
using GrowAGarden.Scripts.Services.Interfaces;
using UnityEngine;

namespace GrowAGarden.Scripts.Services.PlayerData
{
    public class PlayerDataService : IPlayerDataService
    {
        private Transfer.Data.PlayerData _playerData;

        public async UniTask LoadAsync()
        {
            var path = GetSavePath();
            if (File.Exists(path))
            {
                string json = await File.ReadAllTextAsync(path);
                _playerData = JsonUtility.FromJson<Transfer.Data.PlayerData>(json);
            }
            else
            {
                _playerData = new Transfer.Data.PlayerData(); // default values
            }
        }

        public async UniTask SaveAsync()
        {
            string json = JsonUtility.ToJson(_playerData);
            await File.WriteAllTextAsync(GetSavePath(), json);
        }

        public Transfer.Data.PlayerData Get() => _playerData;

        private string GetSavePath()
        {
            return Path.Combine(Application.persistentDataPath, "save.json");
        }
    }
}