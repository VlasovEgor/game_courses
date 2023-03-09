using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "UpgradeCatalog", menuName = "New UpgradeCatalog")]
public class ConveyorUpgradeCatalog : ScriptableObject
{
    [SerializeField] private ConveyorUpgradeConfig[] _configs;
    [SerializeField] private string _conveyorID;

    private void OnEnable()
    {
        for (int i = 0; i < _configs.Length; i++)
        {
            _configs[i].FactoryId = _conveyorID;
        }
    }

    public string GetConveyorId() 
    { 
        return _conveyorID; 
    }

    public UpgradeConfig[] GetAllUpgradeConfigs()
    {
        return _configs;
    }

    public List<Upgrade> GetAllUpgrades()
    {
        var upgrades = new List<Upgrade>();

        for (int i = 0; i < _configs.Length; i++)
        {
            upgrades.Add(_configs[i].InstantiateUpgrade());
        }

        return upgrades;
    }

    public UpgradeConfig FindUpgrade(string id)
    {
        var length = _configs.Length;
        for (var i = 0; i < length; i++)
        {
            var config = _configs[i];
            if (config.Id == id)
            {
                return config;
            }
        }

        throw new Exception($"Config with {id} is not found!");
    }
}
