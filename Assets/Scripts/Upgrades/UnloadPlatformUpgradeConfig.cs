
using UnityEngine;

[CreateAssetMenu(
       fileName = "PlatformUpgradeConfig",
       menuName = "Upgrade/New UnloadPlatformUpgradeConfig"
   )]
public class UnloadPlatformUpgradeConfig: UpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable _platformTable;

    public override Upgrade InstantiateUpgrade()
    {
        return new UnloadPlatformUpgrade(this);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        _platformTable.OnValidate(MaxLevel);
    }
}
