using UnityEngine;
using Zenject;

[CreateAssetMenu(
       fileName = "CreationSpeedConfig",
       menuName = "Upgrade/New LoadCreationSpeedConfig"
   )]
public class CreationSpeedUpgradeConfig : ConveyorUpgradeConfig
{
    [SerializeField] public CreationSpeedTable CreationSpeedTable;

    public override Upgrade InstantiateUpgrade()
    {
        var gameContext = FindObjectOfType<GameContext>(); //crutch
        return new CreationSpeedUpgrade(this,gameContext);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        CreationSpeedTable.OnValidate(MaxLevel);
    }
}
