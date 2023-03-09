using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreationSpeedUpgrade : Upgrade
{
    [SerializeField] private int _upgradeStep;

    private readonly CreationSpeedUpgradeConfig _upgradeConfig;
    private List<SerializedConveyorData> _conveyorList;

    public override string CurrentStats
    {
        get
        {
            return _upgradeConfig.CreationSpeedTable.GetAmount(Level).ToString();
        }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.CreationSpeedTable.UpgradeStep.ToString(); }
    }

    public CreationSpeedUpgrade(CreationSpeedUpgradeConfig config, GameContext gameContext) : base(config)
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
                var timeMultiplicationComponent = _conveyorList[i].ConveyorService.Get<ITimeMultiplicationComponent>();
                var amount = _upgradeConfig.CreationSpeedTable.GetAmount(level);
                timeMultiplicationComponent.SetMultiplier(amount);
            }
        }
    }
}