using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
{
    public event Action<Chest> OnChestLaunched;

    public event Action<Chest> OnChestStarted;

    public event Action<Chest> OnChestFinished;

    [PropertySpace(8), ReadOnly, ShowInInspector] 
    private Dictionary<string, Chest> _chests = new();

    private readonly ChestFactory _factory = new();

    private IGameContext _gameContext;

    public void Construct(GameContext context)
    {
        _gameContext = context;
    }

    public void CreateChests(ChestCatalog chestCatalog)
    {
        var ChestConfigs = chestCatalog.GetAllChests();

        for (int i = 0; i < ChestConfigs.Length; i++)
        {   
            if (_chests.ContainsKey(ChestConfigs[i].Id))
            {
                continue;
            }
                
            var chest = _factory.CreateChest(ChestConfigs[i], this, _gameContext);
            chest.OnCompleted += OnEndChest;

            _chests.Add(ChestConfigs[i].Id, chest);
        }
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
        if (_chests[chestId].IsActive==true)
        {
            Debug.Log("≈Ÿ® –¿ÕŒ Œ“ –€¬¿“‹");
        }
        else
        {
            _chests[chestId].Open();
        }
    }

    void IStartGameListener.OnStartGame()
    {
        StartAllChests();
    }

    void IFinishGameListener.OnFinishGame()
    {
        StopAllChests();
    }

    private void StartAllChests()
    {
        foreach (var currentChest in _chests)
        {

            if (currentChest.Value.IsActive == true)
            {
                continue;
            }

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