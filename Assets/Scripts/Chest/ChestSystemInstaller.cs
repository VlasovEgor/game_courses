using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChestSystemInstaller : MonoInstaller
{
    [SerializeField] private ChestCatalog _chestCatalog;

    [ShowInInspector]
    private ChestManager _manager;

    private Chest.Factory _chestFactory;

    public override void InstallBindings()
    {
        BindChestManager();
        BindChestFactory();
        CreateChests();
        BindChestsMediator();
        SetupTMP();
    }

    private void BindChestManager()
    {
        _manager = Container.Instantiate<ChestManager>();

         Container.BindInterfacesAndSelfTo<ChestManager>().
            FromInstance(_manager).
            AsSingle().
            NonLazy();
    }

    private void BindChestFactory()
    {
        Container.BindFactory<ChestConfig, Chest, Chest.Factory>();
        _chestFactory = Container.Resolve<Chest.Factory>();
    }

    private void BindChestsMediator()
    {
        Container.BindInterfacesAndSelfTo<ChestsMediator>().
            AsSingle().
            NonLazy();
    }

    [Button]
    public void SetupTMP()
    {
        if (_manager.GetAllChests().Count == 0)
        {
            _manager.Setup(CreateChests());
        }
    }

    public List<Chest> CreateChests()
    {
        var chestConfigs = _chestCatalog.GetAllChests();
        var chestList = new List<Chest>();

        for (int i = 0; i < chestConfigs.Length; i++)
        {
            var chest = _chestFactory.Create(chestConfigs[i]);
            chestList.Add(chest);
        }

        return chestList;
    }

    [Button]
    public void OpenChest(string chestId)
    {
        _manager.OpenChest(chestId);
    }
}