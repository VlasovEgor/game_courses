using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChestSystemInstaller : MonoBehaviour, IInitGameListener
{
    [SerializeField] private ChestCatalog _chestCatalog;

    [ShowInInspector, ReadOnly]
    private Dictionary<string, Chest> _chests;

    private ChestManager _manager;
    private ChestFactory _factory;


    [Inject]
    public void Construct(ChestManager chestManager, ChestFactory chestFactory)
    {
        _manager = chestManager;
        _factory = chestFactory;
    }

    public void OnInitGame()
    {
        _manager.Construct(CreateChests());
        _chests = _manager.Chests;
        _manager.StartAllChests();
    }

    public Chest[] CreateChests()
    {
        var chestConfigs = _chestCatalog.GetAllChests();
        var chestsArray = new Chest[chestConfigs.Length];

        for (int i = 0; i < chestsArray.Length; i++)
        {
            var chest = _factory.CreateChest(chestConfigs[i]);
            chestsArray[i] = chest;
        }

        return chestsArray;
    }

    [Button]
    public void OpenChest(string chestId)
    {
        _manager.OpenChest(chestId);
    }
}