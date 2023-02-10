using System;


public class WarehousePresentationModel : IWarehousePresentationModel
{
    public event Action<bool> OnIncreaseButtonStateChanged;
    public event Action<bool> OnDecreaseButtonStateChanged;
    public event Action<bool> OnAddButtonStateChanged;
    public event Action OnStatsChanged;

    private readonly WarehouseAdder _warehouseAdder;
    private readonly IWarehouseComponent _warehouseComponent;
    private readonly IFactoryStoragesComponent _factoryStorages;
    private Storage _storage;

    public WarehousePresentationModel(WarehouseAdder warehouseAdder, IWarehouseComponent warehouseComponent, IFactoryStoragesComponent factoryStorages)
    {
        _warehouseAdder = warehouseAdder;
        _warehouseComponent = warehouseComponent;
        _factoryStorages= factoryStorages;
    }

    public IFactoryStoragesComponent GetFactoryStorages()
    {
        return _factoryStorages;
    }

    public string GetTitle()
    {
        return _storage.Type.ToString();
    }

    public string GetAmount()
    {
        return _warehouseAdder.Amount.ToString();
    }

    public void OnAddClicked()
    {
        _warehouseAdder.Add(_warehouseComponent, _storage);
        OnStatsChanged?.Invoke();
    }

    public void OnButtonSelectionClicked(Storage storage)
    {   
        _storage = storage;
        OnStatsChanged?.Invoke();
    }

    public void OnDecreaseClicked()
    {
        _warehouseAdder.Decrease(_storage);
        OnStatsChanged?.Invoke();
    }

    public void OnIncreaseClicked()
    {
        _warehouseAdder.Increase(_storage);
        OnStatsChanged?.Invoke();
    }

    public bool CanIncrease()
    {
        return _warehouseAdder.CanIncrease(_storage);
    }

    public bool CanDecrease()
    {
        return _warehouseAdder.CanDecrease();
    }

    public bool CanAdd()
    {
        return _warehouseAdder.CanAdd(_storage);
    }
}
