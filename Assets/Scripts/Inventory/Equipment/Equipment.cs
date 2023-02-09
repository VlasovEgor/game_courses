using Sirenix.OdinInspector;
using System.Collections.Generic;
using System;
using System.Linq;

public class Equipment
{
    public event Action<InventoryItem> OnItemAdded;

    public event Action<InventoryItem> OnItemRemoved;

    public Dictionary<EquipType, InventoryItem> Items
    {
        get
        {
            return _items;
        }
    }

    [ReadOnly, ShowInInspector]
    private readonly Dictionary<EquipType, InventoryItem> _items;

    private readonly List<IInventoryItemObserver> _observers;

    public Equipment()
    {
        _items = new Dictionary<EquipType, InventoryItem>();
         _observers = new List<IInventoryItemObserver>();
    }

    public void AddListener(IInventoryItemObserver listener)
    {
        _observers.Add(listener);
    }

    public void RemoveListener(IInventoryItemObserver listener)
    {
        _observers.Remove(listener);
    }

    public bool IsItemExists(InventoryItem item)
    {
        var equipTypeItem = item.GetComponent<EquipTypeComponent>();

        return _items.ContainsKey(equipTypeItem.Type);
    }

    public bool AddItem(InventoryItem item)
    {
        var equipTypeItem = item.GetComponent<EquipTypeComponent>();

        if (_items.ContainsKey(equipTypeItem.Type) == true)
        {
            return false;
        }

        _items.Add(equipTypeItem.Type, item);

        for (int i = 0, count = _observers.Count; i < count; i++)
        {
            var observer = _observers[i];
            observer.OnAddItem(item);
        }
        OnItemAdded?.Invoke(item);
        return true;
    }


    public bool RemoveItem(InventoryItem item)
    {
        var equipTypeItem = item.GetComponent<EquipTypeComponent>();


        if (_items.Remove(equipTypeItem.Type))
        {
            for (int i = 0, count = _observers.Count; i < count; i++)
            {
                var observer = _observers[i];
                observer.OnRemoveItem(item);
            }

            OnItemRemoved?.Invoke(item);
            return true;
        }

        return false;
    }
}