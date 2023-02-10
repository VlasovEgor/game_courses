using System;
using UnityEngine;

[Serializable]
public struct SerializedStorageData
{
    [SerializeField] public Ingredients Ingredients;

    [SerializeField] public Storage Storage;

    public SerializedStorageData(Ingredients type, Storage storage)
    {
        Ingredients = type;
        Storage = storage;
    }
}
