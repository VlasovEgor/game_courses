using UnityEngine;

public class WarehouseAdder : MonoBehaviour
{
    private int _amount;

    private int _numberChanges = 1;
    private Storage _storageComponent;

    public int Amount
    { 
        get 
        {
            return _amount; 
        }
    }

    public void Increase(Storage storage)
    {
        _storageComponent = storage;
        if (CanIncrease(_storageComponent))
        {
            _amount += _numberChanges;
        }
    }

    public bool CanIncrease(Storage storage)
    {
        return _amount <= storage.Value;
    }

    public void Decrease(Storage storage)
    {
        _storageComponent = storage;
        if (CanDecrease())
        {
            _amount -= _numberChanges;
        }
    }

    public bool CanDecrease()
    {
        return _amount > 0;
    }

    public void Add(IWarehouseComponent warehouseComponent, Storage storageComponent)
    {   
        if(CanAdd(storageComponent))
        {
            warehouseComponent.TakeResource(storageComponent.Type, _amount);
            _amount = 0;
        }
    }

    public bool CanAdd(Storage storage)
    {
        return CanIncrease(storage) & CanDecrease();
    }
}
