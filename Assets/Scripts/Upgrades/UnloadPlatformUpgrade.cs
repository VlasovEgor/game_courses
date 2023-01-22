

using UnityEngine;

public class UnloadPlatformUpgrade : Upgrade, IConstructListener
{
    [SerializeField] private int _upgradeStep;

    private IEntity _conveyor;
    private readonly UnloadPlatformUpgradeConfig _upgradeConfig;

    public UnloadPlatformUpgrade(UnloadPlatformUpgradeConfig config) : base(config)
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
        _conveyor.Get<UnloadZoneComponent>().MaxValue= amount;
    }
}

