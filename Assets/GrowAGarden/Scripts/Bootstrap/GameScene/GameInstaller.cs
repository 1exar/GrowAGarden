using System.Collections.Generic;
using GrowAGarden.Scripts.Player;
using GrowAGarden.Scripts.Player.Interfaces;
using GrowAGarden.Scripts.Services;
using GrowAGarden.Scripts.Services.GameLoop;
using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Services.SeedShop;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Bootstrap.GameScene
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputProvider inputProvider;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private List<SeedData> allSeeds;
        [SerializeField] private SeedShopConfig seedShopConfig;
        [SerializeField] private PotConfig potConfig;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerInputProvider>().FromInstance(inputProvider).AsSingle();
            Container.Bind<PlayerController>().FromInstance(playerController).AsSingle();
            
            Container.BindInstance(allSeeds).AsSingle();

            Container.BindInstance(seedShopConfig).AsSingle();

            Container.Bind<SeedShopService>().AsSingle();
            
            Container.BindInterfacesTo<GameLoopService>().AsSingle();
            
            Container.BindInstance(potConfig).AsSingle();
            Container.Bind<PotService>().AsSingle();
        }
    }
}