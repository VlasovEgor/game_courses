using Elementary;
using UnityEngine;

public class WarehouseComponent : MonoBehaviour, IWarehouseComponent
{
    [SerializeField] private Ingredients _type;

    [SerializeField] private LimitedIntBehavior _Storage;

    public Ingredients Type
    {
        get
        {
            return _type;
        }
    }

    public bool CanLoad()
    {
        return !_Storage.IsLimit;
    }
    public void Load(int resources)
    {
        _Storage.Value += resources;
    }

    public bool CanUnload()
    {
        return _Storage.Value > 0;
    }

    public int Unload(int amount)
    {
        if(amount< _Storage.Value)
        {
            var result = amount;
            _Storage.Value -= amount;
            return result;
        }
        else
        {
            return UnloadAll();
        }
    }

    public int UnloadAll()
    {
        var result = _Storage.Value;
        _Storage.Value = 0;
        return result;
    }
}