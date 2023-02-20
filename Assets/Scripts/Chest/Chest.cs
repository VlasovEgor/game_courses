using Elementary;
using System;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using System.Collections.Generic;

public class Chest
{
    public event Action<Chest> OnStarted;
    public event Action<Chest, float> OnTimeChanged;
    public event Action<Chest> OnCompleted;

    [ShowInInspector, ReadOnly]
    public string Id
    {
        get { return _config.Id; }
    }

    [ShowInInspector, ReadOnly]
    public bool IsActive
    {
        get { return _countdown.IsPlaying; }
    }

    [ShowInInspector, ReadOnly]
    public float RemainingSeconds
    {
        get { return _countdown.RemainingTime; }
        set { _countdown.RemainingTime = value; }
    }

    [ShowInInspector, ReadOnly]
    public List<Reward> Rewards 
    { 
        get { return _rewards; }
    }

    public float DurationSeconds
    {
        get { return _config.DurationSeconds; }
    }

    public ChestConfig ChestConfig
    {
        get { return _config; }
        set { _config = value; }
    }

    [Inject] private RewardSystem _rewardSystem;

    private List<Reward> _rewards = new();
    private ChestConfig _config;

    private readonly Countdown _countdown;


    public Chest(ChestConfig chest, MonoBehaviour context)
    {
        _config = chest;
        _countdown = new Countdown(context, _config.DurationSeconds);
    }

    public void Start()
    {
        if (IsActive == true)
        {
            throw new Exception("Already playing!");
        }

        _countdown.OnEnded += OnEndTime;
        _countdown.OnTimeChanged += OnChangeTime;

        OnStarted?.Invoke(this);

        _countdown.Reset();
        _countdown.Play();
    }

    public void Open()
    {
        Start();
    }

    public void Stop()
    {
        _countdown.OnEnded -= OnEndTime;
        _countdown.OnTimeChanged -= OnChangeTime;
    }

    public void GeneratingNewReward()
    {
        _rewards.Clear();
        var chestConfig = ChestConfig;

        var numberRewards = UnityEngine.Random.Range(chestConfig.MinNumbersOfReward, chestConfig.MaxNumbersOfReward);

        for (int i = 0; i < numberRewards; i++)
        {
            var newReward = new Reward();
            newReward.RewardType = RewardType.MONEY;
            newReward.Amount = UnityEngine.Random.Range(chestConfig.MinRewardAmount, chestConfig.MaxRewardAmount);

            _rewards.Add(newReward);
        }
    }

    private void OnChangeTime()
    {
        OnTimeChanged?.Invoke(this, RemainingSeconds);
    }

    private void OnEndTime()
    {
        _countdown.OnEnded -= OnEndTime;
        _countdown.OnTimeChanged -= OnChangeTime;

        OnCompleted?.Invoke(this);
    }
}