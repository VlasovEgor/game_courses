using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCatalog : MonoBehaviour
{
    [ShowInInspector] private Dictionary<string, FactoryService> _factoryDictionary = new();

    public Dictionary<string, FactoryService> FactoryDictionary
    { 
        get { return _factoryDictionary; } 
    }
}
