using GrowAGarden.Scripts.Bootstrap.Interfaces;
using GrowAGarden.Scripts.Services.Interfaces;
using GrowAGarden.Scripts.Services.PlayerData;
using GrowAGarden.Scripts.Signals;
using Zenject;

namespace GrowAGarden.Scripts.Bootstrap
{
    public class LoadingSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<OnGameInitializedSignal>();
            Container.DeclareSignal<OnPlayerDataLoadedSignal>();

            Container.BindInterfacesAndSelfTo<GameBootstrapper>().AsSingle();
            Container.Bind<IPlayerDataService>().To<PlayerDataService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}