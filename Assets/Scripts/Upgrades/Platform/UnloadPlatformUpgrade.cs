using System.Collections.Generic;
using UnityEngine;

public class UnloadPlatformUpgrade : Upgrade
{
    [SerializeField] private int _upgradeStep;

    private List<SerializedConveyorData> _conveyorList;
    private readonly UnloadPlatformUpgradeConfig _upgradeConfig;

    public override string CurrentStats
    {
        get { return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public UnloadPlatformUpgrade(UnloadPlatformUpgradeConfig config, GameContext gameContext) : base(config)
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
                var unloadZoneComponent = _conveyorList[i].ConveyorService.Get<IUnloadZoneComponent>();
                var amount = _upgradeConfig.PlatformTable.GetAmount(level);
                unloadZoneComponent.MaxValue = amount;
            }
        }
    }
}