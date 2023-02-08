using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryUpgradeConfig : UpgradeConfig
{
    [SerializeField] public int FactoryId;

    public override abstract Upgrade InstantiateUpgrade();
    
}
