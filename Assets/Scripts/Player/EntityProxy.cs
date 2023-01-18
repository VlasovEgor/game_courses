
using UnityEngine;

public class EntityProxy : MonoBehaviour,IEntity
{
    [SerializeField] Entity _entity;

    public T Get<T>()
    {
        return _entity.Get<T>();
    }

    public T[] GetAll<T>()
    { 
        return _entity.GetAll<T>();
    }

    public bool TryGet<T>(out T result)
    {
       return _entity.TryGet<T>(out result);
    }
}
