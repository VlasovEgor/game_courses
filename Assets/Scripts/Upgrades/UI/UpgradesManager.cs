using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradesManager
{
    public event Action<Upgrade> OnLevelUp;

    [ReadOnly, ShowInInspector]
    private Dictionary<string, List<Upgrade>> _ugradesDictionary = new();

    private MoneyStorage _moneyStorage;
    private ConveyorUpgradeCatalog[] _catalogs;
    

    public void Construct(MoneyStorage moneyStorage, ConveyorUpgradeCatalog[] catalogs)
    {
        _moneyStorage = moneyStorage;
        _catalogs = catalogs;
    }

    public void Setup()
    {
        for (int i = 0; i < _catalogs.Length; i++)
        {
            List<Upgrade> upgradeList = _catalogs[i].GetAllUpgrades();
            _ugradesDictionary.Add(_catalogs[i].GetConveyorId(), upgradeList);
        }
    }

    public Upgrade[] GetAllUpgrades(string conveyorId)
    {
        return _ugradesDictionary[conveyorId].ToArray();
    }

    [Button]
    public bool CanLevelUp(string conveyorId, string upgradeId)
    {
        var upgrade = GetUpgrades(conveyorId, upgradeId);
        return CanLevelUp(upgrade);
        
    }

    [Button]
    public void LevelUp(string conveyorId, string upgradeId)
    {
        var upgrade = GetUpgrades(conveyorId, upgradeId);
        LevelUp(upgrade);
    }

    public bool CanLevelUp(Upgrade upgrade)
    {
        if (upgrade.IsMaxLevel == true)
        {
            return false;
        }

        var price = upgrade.NextPrice;
        return _moneyStorage.CanSpendMoney(price);
    }

    public void LevelUp(Upgrade upgrade)
    {
        if (CanLevelUp(upgrade) == false)
        {
            Debug.LogWarning($"Can not level up {upgrade.Id}");
        }

        var price = upgrade.NextPrice;
        _moneyStorage.SpendMoney(price);

        upgrade.LevelUp();
        OnLevelUp?.Invoke(upgrade);
    }

    private Upgrade GetUpgrades(string conveyorId, string upgradeId)
    {
        var upgradesList = _ugradesDictionary[conveyorId];

        for (int i = 0; i < upgradesList.Count; i++)
        {
            if (upgradesList[i].Id == upgradeId)
            {
                return upgradesList[i];
            }
        }

        throw new Exception($"Unable to find an upgrade {conveyorId}, {upgradeId}");
    }
}
