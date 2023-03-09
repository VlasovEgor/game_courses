using Sirenix.OdinInspector;
using UnityEngine;

public class ResourceCollectionMechanics : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Conveyor _conveyorService;

    private IFactoryStoragesComponent _storagesComponent;

    private void Awake()
    {
        _storagesComponent = _conveyorService.GetComponent<IFactoryStoragesComponent>();
    }

    [Button]
    public void TakeResources(Ingredients type, int amount)
    {
        var extractedResources = _storagesComponent.Unload(type, amount);
        _warehouse.AddingResources(type, extractedResources);
    }
}