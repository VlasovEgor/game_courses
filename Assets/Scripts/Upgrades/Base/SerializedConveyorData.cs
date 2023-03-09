using System;
using UnityEngine;

[Serializable]
public struct SerializedConveyorData 
{

    [SerializeField] public string ID;

    [SerializeField] public ConveyorService ConveyorService;

    public SerializedConveyorData(string id, ConveyorService conveyorService)
    {
       ID = id;
       ConveyorService = conveyorService;
    }
}
