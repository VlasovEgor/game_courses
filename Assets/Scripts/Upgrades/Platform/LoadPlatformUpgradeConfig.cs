using UnityEngine;
using Zenject;

[CreateAssetMenu(
       fileName = "PlatformsUpgradeConfig",
       menuName = "Upgrade/New LoadPlatformsUpgradeConfig"
   )]
public class LoadPlatformUpgradeConfig : ConveyorUpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable PlatformTable;

    public override Upgrade InstantiateUpgrade()
    {
        var gameContext = FindObjectOfType<GameContext>(); //crutch
        return new LoadPlatformUpgrade(this, gameContext);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        PlatformTable.OnValidate(MaxLevel);
    }
}

