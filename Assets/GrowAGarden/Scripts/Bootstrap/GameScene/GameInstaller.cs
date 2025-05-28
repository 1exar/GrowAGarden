using GrowAGarden.Scripts.Player;
using GrowAGarden.Scripts.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Bootstrap.GameScene
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputProvider _inputProvider;
        [SerializeField] private PlayerController _playerController;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerInputProvider>().FromInstance(_inputProvider).AsSingle();
            Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
        }
    }
}