using Sirenix.OdinInspector;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    [SerializeField] private IFactoryService _factory;

    [Button]
    private void LoadResources(Ingredients type , int resourceCount)
    {
        var storagesComponent = _factory.GetWarehouse().Get<IFactoryStoragesComponent>();

        storagesComponent.Load(type, resourceCount);
    }
}
