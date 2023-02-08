
using Sirenix.OdinInspector;
using System;

[Serializable]
public struct WarehouseCollector
{
    [ShowInInspector]
    public Ingredients TypeIngredient
    {
        get { return _typeIngredient; }
        set { _typeIngredient = value; }
    }

    [ShowInInspector]
    public int AmountIngredient
    {
        get { return _amountIngredient; }
        set { _amountIngredient = value; }
    }

    private int _amountIngredient;
    private Ingredients _typeIngredient;

}