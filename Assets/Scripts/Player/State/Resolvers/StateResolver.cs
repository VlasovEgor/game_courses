using UnityEngine;

public abstract class StateResolver : MonoBehaviour
{
    [SerializeField] protected StateMachine _machine;

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
    }
}