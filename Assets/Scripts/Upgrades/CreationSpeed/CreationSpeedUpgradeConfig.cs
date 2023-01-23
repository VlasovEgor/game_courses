using UnityEngine;

[CreateAssetMenu(
       fileName = "CreationSpeedConfig",
       menuName = "Upgrade/New LoadCreationSpeedConfig"
   )]
public class CreationSpeedUpgradeConfig :  UpgradeConfig
{
    [SerializeField] public CreationSpeedTable _platformTable;

    public override Upgrade InstantiateUpgrade()
    {
        return new CreationSpeedUpgrade(this);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        _platformTable.OnValidate(MaxLevel);
    }
}
