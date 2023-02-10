using UnityEngine;

public class UnloadPlatformUpgrade : Upgrade, IConstructListener, IInitGameListener
{
    [SerializeField] private int _upgradeStep;

    private IEntity _conveyor;
    private readonly UnloadPlatformUpgradeConfig _upgradeConfig;

    public override string CurrentStats
    {
        get { return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public UnloadPlatformUpgrade(UnloadPlatformUpgradeConfig config) : base(config)
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
                _conveyor = factory[i].FactoryService.GetConveyor();
                Debug.Log(_conveyor);
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
        Debug.Log(_conveyor);
        _conveyor.Get<IUnloadZoneComponent>().MaxValue = amount;
    }
}