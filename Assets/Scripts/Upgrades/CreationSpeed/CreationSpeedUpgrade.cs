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
        var amount = _upgradeConfig.CreationSpeedTable.GetAmount(level);
        Debug.Log(_conveyor);
        _conveyor.Get<ITimeMultiplicationComponent>().SetMultiplier(amount);
    }
}