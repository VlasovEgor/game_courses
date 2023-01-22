using UnityEngine;

public abstract class UpgradeConfig:ScriptableObject
{
    [SerializeField] public string Id;
    [SerializeField] public int MaxLevel;

    public abstract Upgrade InstantiateUpgrade();

    protected virtual void OnValidate()
    {
    }
}