using Cysharp.Threading.Tasks;
using GrowAGarden.Scripts.Bootstrap.Interfaces;
using GrowAGarden.Scripts.Services.Interfaces;
using GrowAGarden.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Bootstrap
{
    public class GameBootstrapper : IInitializable
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly ISceneLoader _sceneLoader;
        private readonly SignalBus _signalBus;

        public GameBootstrapper(IPlayerDataService playerDataService, ISceneLoader sceneLoader, SignalBus signalBus)
        {
            _playerDataService = playerDataService;
            _sceneLoader = sceneLoader;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            LoadGameAsync().Forget();
        }

        private async UniTaskVoid LoadGameAsync()
        {
            Debug.Log("Bootstrapping game...");

            await _playerDataService.LoadAsync();

            _signalBus.Fire(new OnPlayerDataLoadedSignal());

            await UniTask.Delay(500);

            _signalBus.Fire(new OnGameInitializedSignal());

            await _sceneLoader.LoadSceneAsync("GameScene");
        }
    }
}