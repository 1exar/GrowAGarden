using System.Collections.Generic;
using GrowAGarden.Scripts.Player;
using GrowAGarden.Scripts.Player.Interfaces;
using GrowAGarden.Scripts.Services.GameLoop;
using GrowAGarden.Scripts.Services.PlayerData;
using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Services.SeedShop;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.UI;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.GameInstallers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Configs")]
        [SerializeField] private List<SeedData> allSeeds;
        [SerializeField] private PotConfig potConfig;
        [SerializeField] private SeedShopConfig seedShopConfig;

        [Header("UI")]
        [SerializeField] private UIManager uiManager;
        
        [Header("Player")]
        [SerializeField] private PlayerInputProvider inputProvider;
        [SerializeField] private PlayerController playerController;
        
        [Header("Other")]
        [SerializeField] private List<PotView> potViews;
        
        
        public override void InstallBindings()
        {
            #region Services

            Container.Bind<SeedShopService>().AsSingle().NonLazy();
            Container.Bind<PotService>().AsSingle();

            Container.BindInterfacesTo<GameLoopService>().AsSingle().NonLazy();;

            #endregion

            #region configs

            Container.BindInstance(allSeeds).AsSingle();
            Container.BindInstance(seedShopConfig).AsSingle();
            Container.BindInstance(potConfig).AsSingle();

            #endregion

            #region Interfaces and Player

            Container.BindInterfacesAndSelfTo<PlayerDataService>().AsSingle().NonLazy();
            Container.Bind<IUIManager>().FromInstance(uiManager).AsSingle();
            Container.Bind<IPlayerInputProvider>().FromInstance(inputProvider).AsSingle();
            Container.Bind<PlayerController>().FromInstance(playerController).AsSingle();

            #endregion

            #region Other

            Container.Bind<List<PotView>>().FromInstance(potViews).AsSingle();

            #endregion
        }
    }
}