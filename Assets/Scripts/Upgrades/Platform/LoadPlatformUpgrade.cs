using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LoadPlatformUpgrade : Upgrade
{   
    private readonly LoadPlatformUpgradeConfig _upgradeConfig;
    private List<SerializedConveyorData> _conveyorList;

    public override string CurrentStats
    {
        get {return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public LoadPlatformUpgrade(LoadPlatformUpgradeConfig config, GameContext gameContext) : base(config)
    {
        _upgradeConfig = config;
        _conveyorList = gameContext.GetService<ConveyorCatalog>().ConveyorList;
        OnUpgrade(Level);
    }

    protected override void OnUpgrade(int level)
    {
        for (int i = 0; i < _conveyorList.Count; i++)
        {
            if (_conveyorList[i].ID == _upgradeConfig.FactoryId)
            {
                var factoryStorages = _conveyorList[i].ConveyorService.Get<IFactoryStoragesComponent>();
                var amount = _upgradeConfig.PlatformTable.GetAmount(level);

                factoryStorages.SetupMaxValueAllStorages(amount);
            }
        }
    }
}