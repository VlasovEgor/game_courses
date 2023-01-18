using UnityEngine;

public class HidingComponent : MonoBehaviour, IHidingComponent
{
    [SerializeField] private BoolBehavior _hidingBehavior;

    public bool isHiding()
    {
        return !_hidingBehavior.Value;
    }
}
