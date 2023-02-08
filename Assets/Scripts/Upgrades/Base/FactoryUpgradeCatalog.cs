using System;
using UnityEngine;

[CreateAssetMenu( fileName = "UpgradeCatalog", menuName = "New UpgradeCatalog")]
public class FactoryUpgradeCatalog : ScriptableObject
{
    [SerializeField] private FactoryUpgradeConfig[] _configs;
    [SerializeField] private string _factoryId;

    private void Awake()
    {
        for (int i = 0; i < _configs.Length; i++)
        {
            _configs[i].FactoryId = _factoryId;
        }
    }

    public UpgradeConfig[] GetAllUpgrades()
    {
        return _configs;
    }

    public UpgradeConfig FindUpgrade(int id)
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
