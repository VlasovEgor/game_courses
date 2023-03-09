using UnityEngine;
using Zenject;

[CreateAssetMenu(
       fileName = "PlatformUpgradeConfig",
       menuName = "Upgrade/New UnloadPlatformUpgradeConfig"
   )]
public class UnloadPlatformUpgradeConfig: ConveyorUpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable PlatformTable;

    public override Upgrade InstantiateUpgrade()
    {   
        var gameContext = FindObjectOfType<GameContext>(); //crutch
        return new UnloadPlatformUpgrade(this, gameContext);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        PlatformTable.OnValidate(MaxLevel);
    }
}
