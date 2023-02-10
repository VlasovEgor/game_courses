using System.Collections.Generic;
using UnityEngine;

public class ScrollStoragesView : MonoBehaviour
{
    [SerializeField] private GameObject _scrollElementPrefab;
    [SerializeField] private Transform _transform;

    private IFactoryStoragesComponent _storages;

    private List<ScrollStorageElement> _scrollStorageElements = new();

    public List<ScrollStorageElement> ScrollStorageElements
    {
        get
        {
            return _scrollStorageElements;
        }
    }

    public void SetFactoryStorages(IFactoryStoragesComponent factoryStorages)
    {
        _storages = factoryStorages;
    }

    private void Start()
    {   
        foreach (var storageStruct in _storages.StoragesList)
        {
            var view = Instantiate(_scrollElementPrefab, _transform);

            var variables = view.GetComponent<ScrollStorageElement>();

            variables.Storage = storageStruct.Storage;
            _scrollStorageElements.Add(variables);
        }
    }
}