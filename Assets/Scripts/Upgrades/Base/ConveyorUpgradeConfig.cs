using UnityEngine;

public abstract class ConveyorUpgradeConfig : UpgradeConfig
{
    [SerializeField] public string FactoryId;

    public override abstract Upgrade InstantiateUpgrade();
    
}
