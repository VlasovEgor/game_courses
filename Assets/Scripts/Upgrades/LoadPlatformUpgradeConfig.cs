using UnityEngine;

[CreateAssetMenu(
       fileName = "PlatformsUpgradeConfig",
       menuName = "Upgrade/New LoadPlatformsUpgradeConfig"
   )]
public class LoadPlatformUpgradeConfig : UpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable _platformTable;

    public override Upgrade InstantiateUpgrade()
    {
        return new LoadPlatformUpgrade(this);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        _platformTable.OnValidate(MaxLevel);
    }
}

