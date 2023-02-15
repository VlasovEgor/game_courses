using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChestTest : MonoBehaviour, IConstructListener
{
    [ShowInInspector, ReadOnly]
    private Chest _chest;

    [Inject] private IGameContext _gameContext;

    [ShowInInspector] private Dictionary<string, Chest> _chests = new();

    public void Construct(GameContext context)
    {
        _gameContext = context;
    }

    [Button]
    private void ActivateChest(ChestConfig config)
    {
        _chest = config.InstatiateChest(context: this, _gameContext);
        _chests.Add(config.Id, _chest);
        _chest.Start();
    }
}
