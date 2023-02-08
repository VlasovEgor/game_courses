using UnityEngine;

public class FactoryService : MonoBehaviour, IFactoryService
{
    [SerializeField] private Entity _warehouse;
    [SerializeField] private Entity _conveyor;

    public Entity GetWarehouse()
    {
        return _warehouse;
    }

    public Entity GetConveyor() 
    { 
        return _conveyor;
    }
}
