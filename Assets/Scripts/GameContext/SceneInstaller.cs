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

    public override void InstallBindings()
    {
        BindGameContext();
        BindChestFactory();
        BindMoneyStorage();
        BindRewardSystem();
        BindRealtimeManager();
        BindRealtimeRepository();
        BindTimeShiftEmitter();
        BindChestManager();
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
            AsSingle();
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
        Container.Bind<ChestManager>().
            FromInstance(_chestManager).
           AsSingle();
    }

}
