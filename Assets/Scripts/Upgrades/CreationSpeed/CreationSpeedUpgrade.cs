using UnityEngine;

public class CreationSpeedUpgrade : Upgrade, IConstructListener, IInitGameListener
{
    [SerializeField] private int _upgradeStep;

    private IEntity _conveyor;
    private readonly CreationSpeedUpgradeConfig _upgradeConfig;

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

    public CreationSpeedUpgrade(CreationSpeedUpgradeConfig config) : base(config)
    {
        _upgradeConfig = config;
    }

    public void Construct(GameContext context)
    {
        FactoryService factory = context.GetService<FactoryCatalog>().FactoryDictionary[_upgradeConfig.FactoryId];
        _conveyor = factory.GetConveyor();
    }

    public void Initialization()
    {
        OnUpgrade(Level);
    }

    protected override void OnUpgrade(int level)
    {
        var amount = _upgradeConfig.CreationSpeedTable.GetAmount(level);
        _conveyor.Get<ITimeMultiplicationComponent>().SetMultiplier(amount);
    }
}