using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FactoryStoragesComponent : MonoBehaviour, IFactoryStoragesComponent
{
    [SerializeField] private List<SerializedStorageData> _storagesList = new();

    public List<SerializedStorageData> StoragesList
    {
        get
        {
            return _storagesList;
        }
    }

    public struct StorageData
    {
        public Ingredients Ingredients;
        public Storage Storage;
    }


    public bool CanLoad(Ingredients storageType)
    {
        var storage = FindStorage(storageType);
        return storage.CanLoad();
    }

    public void Load(Ingredients storageType, int resources)
    {
        var storage = FindStorage(storageType);
        storage.Load(resources);
    }

    public bool CanUnload(Ingredients storageType)
    {
        var storage = FindStorage(storageType);
        return storage.CanUnload();
    }

    public int Unload(Ingredients storageType, int amount)
    {
        var storage = FindStorage(storageType);
        return storage.Unload(amount);
    }

    public int UnloadAll(Ingredients storageType)
    {
        var storage = FindStorage(storageType);
        return storage.UnloadAll();
    }

    public void SetupMaxValueAllStorages(int value)
    {
        foreach (var storageStruct in _storagesList)
        {
            storageStruct.Storage.SetupMaxValue(value);
        }
    }

    private Storage FindStorage(Ingredients storageType)
    {
        for (int i = 0; i < _storagesList.Count; i++)
        {
            if (_storagesList[i].Ingredients== storageType)
            {
                return _storagesList[i].Storage;
            }
        }

        throw new Exception("there is no such storage");
    }
}