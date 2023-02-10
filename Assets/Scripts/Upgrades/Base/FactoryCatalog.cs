using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FactoryCatalog : MonoBehaviour
{
    [SerializeField] private List<SerializedFactoryData> _factoryList = new();

    public List<SerializedFactoryData> FactoryList
    {
        get { return _factoryList; }
    }
}
