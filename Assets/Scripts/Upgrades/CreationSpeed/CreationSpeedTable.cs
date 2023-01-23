using System;
using UnityEngine;

[Serializable]
public class CreationSpeedTable
{
    public float UpgradeStep
    {
        get { return _upgradeStep; }
    }

    [SerializeField] private float _startAmount = 1;
    [SerializeField] private float _upgradeStep = 0.2f;

    private float[] _levels;

    public float GetAmount(int level)
    {
        var index = level - 1;
        return _levels[index];
    }

    public void OnValidate(int maxLevel)
    {
        _levels = new float[maxLevel];

        var currentAmount = _startAmount;
        for (var i = 0; i < maxLevel; i++)
        {
            _levels[i] = currentAmount;
            currentAmount += _upgradeStep;
        }
    }
}
