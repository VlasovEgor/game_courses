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
        _factoryStorages=context.GetService<IFactoryService>().GetWarehouse().Get<IFactoryStoragesComponent>();
    }

    public void Initialization()
    {
        OnUpgrade(Level);
    }

    protected override void OnUpgrade(int level)
    {
        var amount = _upgradeConfig.PlatformTable.GetAmount(level);
        _factoryStorages.SetupMaxValueAllStorages(amount);
    }
}