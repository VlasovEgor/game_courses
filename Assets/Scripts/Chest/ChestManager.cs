using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ChestManager : IInitializable, IDisposable
{
    public event Action<Chest> OnChestLaunched;

    public event Action<Chest> OnChestStarted;

    public event Action<Chest> OnChestFinished;

    [Inject] private RewardSystem _rewardSystem;

    public Dictionary<string, Chest> Chests
    {
        get { return _chests; }
    }

    [PropertySpace(8), ReadOnly, ShowInInspector] 
    private Dictionary<string, Chest> _chests = new();

    public void Construct(Chest[] chests)
    {
        _chests = chests.ToDictionary(it => it.Id);
    }

    public List<Chest> GetActiveChests()
    {
        var activeChests = new List<Chest>();

        foreach (var currentChest in _chests)
        {

            if (currentChest.Value.IsActive == true)
            {
                activeChests.Add(currentChest.Value);
            }
        }

        return activeChests;
    }

    public void OpenChest(string chestId)
    {
        if (_chests[chestId].IsActive == true)
        {
            Debug.Log("≈Ÿ® –¿ÕŒ Œ“ –€¬¿“‹");
        }
        else
        {
            _chests[chestId].Open();
            ReceivingReward(_chests[chestId].Rewards);
            _chests[chestId].GeneratingNewReward();
        }
    }

    private void ReceivingReward(List<Reward> rewards)
    {
        _rewardSystem.AccrueReward(rewards);
    }

    public void Initialize()
    {
        StartAllChests();
    }

    public void Dispose()
    {
        StopAllChests();
    }

    public void StartAllChests()
    {
        foreach (var currentChest in _chests)
        {

            if (currentChest.Value.IsActive == true)
            {
                continue;
            }

            currentChest.Value.GeneratingNewReward();

            currentChest.Value.Start();

            OnChestStarted?.Invoke(currentChest.Value);
            OnChestLaunched?.Invoke(currentChest.Value);
        }
    }

    private void StopAllChests()
    {
        foreach (var currentChest in _chests)
        {

            if (currentChest.Value.IsActive == false)
            {
                continue;
            }

            currentChest.Value.OnCompleted -= OnEndChest;
            currentChest.Value.Stop();
        }
    }

    private void OnEndChest(Chest chest)
    {
        chest.OnCompleted -= OnEndChest;
        OnChestFinished?.Invoke(chest);
    }
}