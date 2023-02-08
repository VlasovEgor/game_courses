using System;
using System.Collections.Generic;
using UnityEngine;

public class ScrollStoragesView : MonoBehaviour
{
    [SerializeField] private GameObject _scrollElementPrefab;
    [SerializeField] private Transform _transform;
    [SerializeField] private FactoryStoragesComponent _storages;

    private List<ScrollStorageElement> _scrollStorageElements = new();

    public List<ScrollStorageElement> ScrollStorageElements
    {
        get
        {
            return _scrollStorageElements;
        }
    }

    private void Start()
    {   
        foreach (var storage in _storages.StoragesDictionary)
        {
            var view = Instantiate(_scrollElementPrefab, _transform);

            var variables = view.GetComponent<ScrollStorageElement>();

            variables.Storage = storage.Value;
            _scrollStorageElements.Add(variables);
        }
    }

   
}
