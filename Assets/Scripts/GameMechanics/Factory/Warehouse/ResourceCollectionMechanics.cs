using Sirenix.OdinInspector;
using UnityEngine;

public class ResourceCollectionMechanics : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;

    private IFactoryStoragesComponent _storagesComponent;

    private void Awake()
    {
        _storagesComponent = _warehouse.GetComponent<Entity>().Get<IFactoryStoragesComponent>();
    }

    [Button]
    public void TakeResources(Ingredients type, int amount)
    {
        var extractedResources = _storagesComponent.Unload(type, amount);
        _warehouse.AddingResources(type, extractedResources);
    }
}