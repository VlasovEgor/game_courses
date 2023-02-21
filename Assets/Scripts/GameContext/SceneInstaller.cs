using System;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameContext _gameContext;
    [SerializeField] private MoneyStorage _moneyStorage;
    [SerializeField] private RewardSystem _rewardSystem;
    [SerializeField] private RealtimeManager _realtimeManager;
    [SerializeField] private TimeShiftEmitter _timeShiftEmitter;
    [SerializeField] private ChestManager _chestManager;
    [SerializeField] private ChestSystemInstaller _chestSystemInstaller;
    [SerializeField] private MonoBehaviour _monoBehaviour;

    public override void InstallBindings()
    {
        BindInstallerInterfaces();
        BindGameContext();
        BindMonoBehaviour();
        BindChestFactory();
        BindMoneyStorage();
        BindRewardSystem();
        BindRealtimeManager();
        BindRealtimeRepository();
        BindTimeShiftEmitter();
        BindChestSystemInstaller();
        BindChestManager();    
    }

    public void BindInstallerInterfaces()
    {
       Container.BindInterfacesTo<SceneInstaller>().
           FromInstance(this).
           AsSingle();
    }

    private void BindMonoBehaviour()
    {
        Container.Bind<MonoBehaviour>().
           FromInstance(_monoBehaviour).
           AsSingle();
    }

    private void BindGameContext()
    {
        Container.Bind<IGameContext>().
            To<GameContext>().
            FromInstance(_gameContext).
            AsSingle();
    }

    private void BindChestFactory()
    {   
        Container.Bind<ChestFactory>().
            AsSingle().NonLazy();
    }

    private void BindChestSystemInstaller()
    {
        Container.Bind(typeof(ChestSystemInstaller), typeof(IInitializable)).
            FromInstance(_chestSystemInstaller)
           .AsSingle();
    }

    private void BindMoneyStorage()
    {
        Container.Bind<MoneyStorage>().
            FromInstance(_moneyStorage).
            AsSingle();
    }

    private void BindRewardSystem()
    {
        Container.Bind<RewardSystem>().
            FromInstance(_rewardSystem).
            AsSingle();
    }

    private void BindRealtimeManager()
    {
        Container.Bind<RealtimeManager>().
           FromInstance(_realtimeManager).
           AsSingle();
    }

    private void BindRealtimeRepository()
    {
        Container.Bind<RealtimeRepository>().
            AsSingle();
    }

    private void BindTimeShiftEmitter()
    {
        Container.Bind<TimeShiftEmitter>().
            FromInstance(_timeShiftEmitter).
           AsSingle();
    }

    private void BindChestManager()
    {
        Container.Bind(typeof(ChestManager), typeof(IInitializable), typeof(IDisposable))
            .To<ChestManager>()
            .AsSingle();
    }

}