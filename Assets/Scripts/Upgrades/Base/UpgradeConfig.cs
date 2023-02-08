﻿using UnityEngine;

public abstract class UpgradeConfig: ScriptableObject
{
    [SerializeField] public int Id;
    [SerializeField] public int MaxLevel;
    [SerializeField] public PriceTable PriceTable;
    [SerializeField] public UpgradeInfo UpgradeInfo;

    public abstract Upgrade InstantiateUpgrade();

    protected virtual void OnValidate()
    {
    }
}