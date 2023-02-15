using System;
using UnityEngine;
using Zenject;

public class MiddleChest : Chest
{
    private IGameContext _gameContext;
    [Inject] private RewardSystem _rewardSystem;
    private ChestConfig _chestConfig;

    public MiddleChest(ChestConfig chestConfig, MonoBehaviour context, IGameContext gameContext) : base(chestConfig, context)
    {
        _chestConfig = chestConfig;
        _gameContext = gameContext;
    }

    protected override void OnStart()
    {
        Debug.Log("Middle chest start");
    }

    protected override void OnOpen()
    {
        _rewardSystem = _gameContext.GetService<RewardSystem>();
        _rewardSystem.AccrueReward(_chestConfig.Rewards);
        Debug.Log("the reward is received");
        Start();
    }

    protected override void OnStop()
    {
        Debug.Log("Middle chest stop");
    }

    protected override void GeneratingNewReward()
    {
        _chestConfig.Rewards.Clear();

        var numberRewards = random.Next(_chestConfig.MinNumbersOfReward, _chestConfig.MaxNumbersOfReward);

        for (int i = 0; i < numberRewards; i++)
        {
            var newReward = new Reward();
            newReward.RewardType = RewardType.MONEY;
            newReward.Amount = random.Next(50);

            _chestConfig.Rewards.Add(newReward);
        }
    }
}
