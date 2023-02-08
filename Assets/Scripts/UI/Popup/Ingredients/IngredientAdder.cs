using UnityEngine;

public class IngredientAdder : MonoBehaviour
{
    public int Amount;

    private int _numberChanges=1;

    public void Add(Storage storage)
    {
        if (CanAdd(storage))
        {
            storage.Load(Amount);
        }
    }

    public bool CanAdd(Storage storage)
    {
        return storage.CanLoad() && CanIncrease(storage) && CanDecrease();
    }

    public void Increase(Storage storage)
    {
        if(CanIncrease(storage)) 
        {
            Amount += _numberChanges;
        }
    }

    public bool CanIncrease(Storage storage)
    {
        return Amount <= (storage.MaxValue - storage.Value);
    }

    public void Decrease()
    {
        if(CanDecrease())
        {
            Amount -= _numberChanges;
        }
    }

    public bool CanDecrease()
    {
        return Amount > 0;
    }

}
