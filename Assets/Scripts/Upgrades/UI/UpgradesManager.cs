using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class UpgradesManager
{
    public event Action<Upgrade> OnLevelUp;

    [ReadOnly, ShowInInspector]
    private Upgrade[][] _upgrades;

    private MoneyStorage _moneyStorage;
    private FactoryUpgradeCatalog[] _catalogs;

    public void Construct(MoneyStorage moneyStorage, FactoryUpgradeCatalog[] catalogs)
    {
        _moneyStorage = moneyStorage;
        _catalogs = catalogs;
    }

    public void Setup(Upgrade[][] upgrades)
    {
        _upgrades = new Upgrade[_catalogs.Length][];

        for (int i = 0; i < _upgrades.Length; i++)
        {
            for (int j = 0; j < _upgrades[i].Length; j++)
            {
                var upgrade = upgrades[i][j];
                _upgrades[i][upgrade.Id] = upgrade;
            }
        }
    }

    public Upgrade GetUpgrades(int factoryId,int upgradeId)
    {
        return _upgrades[factoryId][upgradeId];
    }

    public Upgrade[] GetAllUpgrades(int factoryId)
    {
        return _upgrades[factoryId].ToArray();
    }

    [Button]
    public bool CanLevelUp(int factoryId,int upgradeId)
    {   
        var upgrade = _upgrades[factoryId][upgradeId];
        return CanLevelUp(upgrade);
    }

    [Button]
    public void LevelUp(int factoryId, int upgradeId)
    {
        var upgrade = _upgrades[factoryId][upgradeId];
        LevelUp(upgrade);
    }

    public bool CanLevelUp(Upgrade upgrade)
    {
        if (upgrade.IsMaxLevel)
        {
            return false;
        }

        var price = upgrade.NextPrice;
        return _moneyStorage.CanSpendMoney(price);
    }

    public void LevelUp(Upgrade upgrade)
    {
        if (!CanLevelUp(upgrade))
        {
            throw new Exception($"Can not level up {upgrade.Id}");
        }

        var price = upgrade.NextPrice;
        _moneyStorage.SpendMoney(price);

        upgrade.LevelUp();
        OnLevelUp?.Invoke(upgrade);
    }

   
}
