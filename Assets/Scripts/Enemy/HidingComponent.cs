using UnityEngine;

public class HidingComponent : MonoBehaviour, IHidingComponent
{
    [SerializeField] private BoolBehavior _hidingBehavior;

    public bool IsHiding()
    {
        return !_hidingBehavior.Value;
    }
}
