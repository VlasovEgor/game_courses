using System;
using UnityEngine;

[Serializable]
public struct SerializedConveyorData 
{

    [SerializeField] public string ID;

    [SerializeField] public Conveyor Conveyor;

    public SerializedConveyorData(string id, Conveyor conveyorService)
    {
       ID = id;
       Conveyor = conveyorService;
    }
}
