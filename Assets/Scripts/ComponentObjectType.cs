using UnityEngine;

public class ComponentObjectType : MonoBehaviour
{
    public ObjectType ObjectType
    {
        get { return _objectType; }
    }

    [SerializeField] private ObjectType _objectType;
}
