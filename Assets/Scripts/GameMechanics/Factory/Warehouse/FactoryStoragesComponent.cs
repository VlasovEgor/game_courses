using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class FactoryStoragesComponent : MonoBehaviour, IFactoryStoragesComponent
{
    [ShowInInspector] private Dictionary<Ingredients, Storage> _storagesDictionary = new();

    public Dictionary<Ingredients, Storage> StoragesDictionary
    {
        get
        {
            return _storagesDictionary;
        }
    }

    public bool CanLoad(Ingredients storageType)
    {
        var storage = _storagesDictionary[storageType];
        return storage.CanLoad();
    }

    public void Load(Ingredients storageType, int resources)
    {
        var storage = _storagesDictionary[storageType];
        storage.Load(resources);
    }

    public bool CanUnload(Ingredients storageType)
    {
        var storage = _storagesDictionary[storageType];
        return storage.CanUnload();
    }

    public int Unload(Ingredients storageType, int amount)
    {
        var storage = _storagesDictionary[storageType];
        return storage.Unload(amount);
    }

    public int UnloadAll(Ingredients storageType)
    {
        var storage = _storagesDictionary[storageType];
        return storage.UnloadAll();
    }

    public void SetupMaxValueAllStorages(int value)
    {
        foreach (var storage in _storagesDictionary)
        {
            storage.Value.SetupMaxValue(value);
        }
    }
}