using System;

public abstract class Upgrade
{
    public string Id
    {
        get
        {
            return _upgradeConfig.Id;
        }
    }

    public int Level
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            _currentLevel = value;
        }
    }

    public int MaxLevel 
    { 
        get
        {
            return _upgradeConfig.MaxLevel;
        }
    }


    public bool IsMaxLevel
    {
        get
        {
            return _currentLevel == MaxLevel;

        }
    }

    private int _currentLevel;
    private readonly UpgradeConfig _upgradeConfig;

    public Upgrade(UpgradeConfig config)
    {
        _currentLevel = 1;
        _upgradeConfig= config;
    }

    public void LevelUp()
    {
        if (IsMaxLevel == true)
        {
            throw new Exception("Max level is reached!");
        }

        _currentLevel++;
        OnUpgrade(_currentLevel);
    }

    protected abstract void OnUpgrade(int level);
}
