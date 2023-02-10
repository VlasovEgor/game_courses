using System;
using UnityEngine;

[Serializable]
public struct SerializedFactoryData 
{

    [SerializeField] public int ID;

    [SerializeField] public FactoryService FactoryService;

    public SerializedFactoryData(int id, FactoryService factoryService)
    {
       ID= id;
       FactoryService = factoryService;
    }
}
