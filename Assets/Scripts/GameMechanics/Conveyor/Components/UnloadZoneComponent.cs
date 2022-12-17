using Elementary;
using UnityEngine;

public class UnloadZoneComponent : MonoBehaviour, IUnloadZoneComponent
{

    [SerializeField] private LimitedIntBehavior _unloadStorage;

    public bool CanUnload()
    {
        return _unloadStorage.Value > 0;
    }

    public int UnloadAll()
    {
        var result = _unloadStorage.Value;
        _unloadStorage.Value = 0;
        return result;
    }
}