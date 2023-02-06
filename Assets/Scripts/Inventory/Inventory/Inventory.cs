using Sirenix.OdinInspector;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory
{
    public event Action<InventoryItem> OnItemAdded;

    public event Action<InventoryItem> OnItemRemoved;

    [ReadOnly, ShowInInspector]
    private readonly List<InventoryItem> _items;

    public Inventory()
    {
        _items = new List<InventoryItem>();
    }

    public void SetupItems(InventoryItem[] item)
    {
        _items.Clear();
        _items.AddRange(item);
    }

    public bool AddItem(InventoryItem item)
    {
        if (_items.Contains(item))
        {
            return false;
        }

        _items.Add(item);

        return true;
    }

    public bool RemoveItem(string itemName)
    {
        for (var i = _items.Count - 1; i >= 0; i--)
        {
            var item = _items[i];
            if (item.Name == itemName)
            {
                return RemoveItem(item);
            }
        }

        return false;
    }

    public bool RemoveItem(InventoryItem item)
    {
        if (IsItemExists(item) == true)
        {
            _items.Remove(item);
            return true;
        }

        return false;
    }

    public bool IsItemExists(InventoryItem item)
    {
        return _items.Contains(item);
    }

    public bool IsEmpty()
    {
        return _items.Count <= 0;
    }

    public InventoryItem[] GetAllItems()
    {
        return _items.ToArray();
    }

    public List<InventoryItem> GetAllItemsUnsafe()
    {
        return _items;
    }

    public bool FindItemFirst(InventoryItemFlags flags, out InventoryItem item)
    {
        for (int i = 0, count = _items.Count; i < count; i++)
        {
            item = _items[i];
            if ((item.Flags & flags) == flags)
            {
                return true;
            }
        }

        item = default;
        return false;
    }

    public bool FindItemFirst(string name, out InventoryItem item)
    {
        for (int i = 0, count = _items.Count; i < count; i++)
        {
            item = _items[i];
            if (item.Name == name)
            {
                return true;
            }
        }

        item = default;
        return false;
    }

    public bool FindItemLast(string name, out InventoryItem item)
    {
        for (var i = _items.Count - 1; i >= 0; i--)
        {
            item = _items[i];
            if (item.Name == name)
            {
                return true;
            }
        }

        item = default;
        return false;
    }

    public bool FindItemFirst(out InventoryItem item, Func<InventoryItem, bool> predicate)
    {
        for (int i = 0, count = _items.Count; i < count; i++)
        {
            item = _items[i];
            if (predicate.Invoke(item))
            {
                return true;
            }
        }

        item = default;
        return false;
    }

    public InventoryItem[] FindItems(InventoryItemFlags flags)
    {
        var result = new List<InventoryItem>();
        for (int i = 0, count = _items.Count; i < count; i++)
        {
            var item = _items[i];
            if ((item.Flags & flags) == flags)
            {
                result.Add(item);
            }
        }

        return result.ToArray();
    }

    public InventoryItem[] FindItems(string name)
    {
        var result = new List<InventoryItem>();
        for (int i = 0, count = _items.Count; i < count; i++)
        {
            var item = _items[i];
            if (item.Name == name)
            {
                result.Add(item);
            }
        }

        return result.ToArray();
    }

    public int CountItems(InventoryItemFlags flags)
    {
        var result = 0;
        for (int i = 0, count = _items.Count; i < count; i++)
        {
            var item = _items[i];
            if ((item.Flags & flags) == flags)
            {
                result++;
            }
        }

        return result;
    }

    public int CountItems(string itemName)
    {
        var result = 0;
        for (int i = 0, count = _items.Count; i < count; i++)
        {
            var item = _items[i];
            if (item.Name == itemName)
            {
                result++;
            }
        }

        return result;
    }
}