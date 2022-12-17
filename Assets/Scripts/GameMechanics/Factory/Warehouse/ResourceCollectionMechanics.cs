using Sirenix.OdinInspector;
using UnityEngine;

public class ResourceCollectionMechanics : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;

    private IWarehouseComponent[] _unloadComponents;

    private void Awake()
    {
        _unloadComponents = _warehouse.GetComponent<Entity>().GetAll<IWarehouseComponent>();
    }

    [Button]
    private void TakeResources(Ingredients type, int amount)
    {
        for (int i = 0; i < _unloadComponents.Length; i++)
        {
            if (_unloadComponents[i].Type == type && _unloadComponents[i].CanUnload())
            {
                var extractedResources = _unloadComponents[i].Unload(amount);
                _warehouse.AddingResources(_unloadComponents[i].Type, extractedResources);

                Debug.Log($"Extracted resources {extractedResources}");
            }
        }
    }
}