using System;
using ECS_Lite_Test;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DataSoInstaller", menuName = "Installers/DataSoInstaller")]
public class DataSoInstaller : ScriptableObjectInstaller<DataSoInstaller>
{
    public AssetData AssetData;
    public LevelConstructScheme LevelConstructScheme;
    public GameConfiguration GameConfiguration;
    public override void InstallBindings()
    {
        Container.Bind<AssetData>().FromInstance(AssetData).AsSingle().NonLazy();
        Container.Bind<GameConfiguration>().FromInstance(GameConfiguration).AsSingle().NonLazy();
        Container.Bind<LevelConstructScheme>().FromInstance(LevelConstructScheme).AsSingle().NonLazy();
    }
}