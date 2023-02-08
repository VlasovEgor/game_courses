using Elementary;
using System;
using UnityEngine;

public class Storage: MonoBehaviour
{
    [SerializeField] private Ingredients _type;

    [SerializeField] private LimitedIntBehavior _amountStorage;

    public Ingredients Type
    {
        get { return _type; }
    }

    public int Value
    { 
        get { return _amountStorage.Value;} 
    }

    public int MaxValue
    {
        get { return _amountStorage.MaxValue;}
    }

    public bool CanLoad()
    {
        return !_amountStorage.IsLimit;
    }

    public void Load(int resources)
    {
        if (CanLoad() == false)
        {
            return;
        }

        _amountStorage.Value += resources;
    }

    public bool CanUnload()
    {
        return _amountStorage.Value > 0;
    }

    public int Unload(int amount)
    {
        if (CanUnload() == false)
        {
            throw new Exception("there is no storage with such an ingredient");
        }
        else
        {

            if (amount < _amountStorage.Value)
            {
                var result = amount;
                _amountStorage.Value -= amount;
                return result;
            }
            else
            {
                return UnloadAll();
            }
        }
    }

    public int UnloadAll()
    {
        var result = _amountStorage.Value;
        _amountStorage.Value = 0;
        return result;
    }

    public void SetupMaxValue(int value)
    { 
        _amountStorage.MaxValue= value;
    }
}
