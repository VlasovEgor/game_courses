using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public string Name
    {
        get
        {
            return _name;
        }
    }

    public InventoryItemFlags Flags
    {
        get
        {
            return _flags;
        }
    }

    public InventoryItemMetadata Metadata
    {
        get
        {
            return _metadata;
        }
    }

    [SerializeField] private string _name;

    [SerializeField] private InventoryItemFlags _flags;

    [SerializeField] private InventoryItemMetadata _metadata;

    [SerializeReference] private object[] _components;

    public InventoryItem(
        string name, InventoryItemFlags flags,
        InventoryItemMetadata metadata, params object[] components
        )
    {
        _name = name;
        _flags = flags;
        _metadata = metadata;
        _components = components;
    }

    public T GetComponent<T>()
    {
        for (int i = 0; i < _components.Length; i++)
        {
            var component = _components[i];
            if (component is T result)
            {
                return result;
            }
        }

        throw new Exception($"Component of type {typeof(T)} is not found!");
    }

    public InventoryItem Clone()
    {
        return new InventoryItem(_name,_flags, _metadata, CloneComponents());
    }

    private object[] CloneComponents()
    {
        var count = _components.Length;
        var result  = new object[count];

        for (int i = 0; i < count; i++)
        {
            var component = _components[i];

            if(component is ICloneable cloneable)
            {
                component= cloneable.Clone();
            }

            result[i] = component;
        }

        return result;
    }
}
