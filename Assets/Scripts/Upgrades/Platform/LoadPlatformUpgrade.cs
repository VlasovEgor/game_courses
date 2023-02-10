using UnityEngine;

public class LoadPlatformUpgrade : Upgrade, IConstructListener, IInitGameListener
{   
    private IFactoryStoragesComponent _factoryStorages;
    private readonly LoadPlatformUpgradeConfig _upgradeConfig;

    public override string CurrentStats
    {
        get {return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public LoadPlatformUpgrade(LoadPlatformUpgradeConfig config) : base(config)
    {
        _upgradeConfig = config;
    }

    public void Construct(GameContext context)
    {
        var factory = context.GetService<FactoryCatalog>().FactoryList;
        for (int i = 0; i < factory.Count; i++)
        {
            if (factory[i].ID == _upgradeConfig.FactoryId)
            {
                _factoryStorages = factory[i].FactoryService.GetWarehouse().Get<IFactoryStoragesComponent>();
                Debug.Log(_factoryStorages);
            }
        }
    }

    public void Initialization()
    {
        OnUpgrade(Level);
    }

    protected override void OnUpgrade(int level)
    {
        var amount = _upgradeConfig.PlatformTable.GetAmount(level);
        Debug.Log(_factoryStorages);
        _factoryStorages.SetupMaxValueAllStorages(amount);
    }
}