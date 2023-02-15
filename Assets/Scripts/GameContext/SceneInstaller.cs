using System;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameContext _gameContext;
    [SerializeField] private MoneyStorage _moneyStorage;
    [SerializeField] private RewardSystem _rewardSystem;

    public override void InstallBindings()
    {
        BindGameContext();
        BindChestFactory();
        BindMoneyStorage();
        BindRewardSystem();
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

}
