using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConveyorCatalog : MonoBehaviour
{
    [SerializeField] private List<SerializedConveyorData> _conveyorList = new();

    public List<SerializedConveyorData> GetAllConveyorsData()
    {
        return _conveyorList;
    }
}
