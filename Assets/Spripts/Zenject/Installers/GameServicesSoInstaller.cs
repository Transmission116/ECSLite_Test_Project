using ECS_Lite_Test;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameServicesSoInstaller", menuName = "Installers/GameServicesSoInstaller")]
public class GameServicesSoInstaller : ScriptableObjectInstaller<GameServicesSoInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<PrefabFactory>().FromNew().AsSingle().NonLazy();
        Container.Bind<ITimeService>().To<UnityTimeService>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EcsStartup>().AsSingle().NonLazy();
    }
}