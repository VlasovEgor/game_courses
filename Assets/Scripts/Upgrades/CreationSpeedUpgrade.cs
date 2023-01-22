using UnityEngine;

public class CreationSpeedUpgrade : Upgrade, IConstructListener
{
    [SerializeField] private int _upgradeStep;

    private IEntity _conveyor;
    private readonly CreationSpeedUpgradeConfig _upgradeConfig;

    public CreationSpeedUpgrade(CreationSpeedUpgradeConfig config) : base(config)
    {
        _upgradeConfig = config;
    }

    public void Construct(GameContext context)
    {
        _conveyor = context.GetService<IEntity>().Get<IEntity>();
    }

    protected override void OnUpgrade(int level)
    {
        var amount = _upgradeConfig._platformTable.GetAmount(level);
        _conveyor.Get<TimeMultiplicationComponent>().SetMultiplier(amount);
    }
}
