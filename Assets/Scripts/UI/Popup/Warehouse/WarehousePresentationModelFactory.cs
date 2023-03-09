using UnityEngine;

public class WarehousePresentationModelFactory : MonoBehaviour,IConstructListener
{
    private WarehouseAdder _warehouseAdder;
    IWarehouseComponent _warehouseComponent;
    IFactoryStoragesComponent _factoryStorages;

    public void Construct(GameContext context)
    {
        _warehouseAdder = context.GetService<WarehouseAdder>();
        _warehouseComponent= context.GetService<Conveyor>().Get<IWarehouseComponent>();
        _factoryStorages= context.GetService<Conveyor>().Get<IFactoryStoragesComponent>();
    }

    public WarehousePresentationModel CreatePresenter()
    {
        return new WarehousePresentationModel(_warehouseAdder, _warehouseComponent, _factoryStorages);
    }
}
