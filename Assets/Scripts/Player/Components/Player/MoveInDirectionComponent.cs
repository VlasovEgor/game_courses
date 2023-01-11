
using System;
using UnityEngine;

public class MoveInDirectionComponent : MonoBehaviour, IMoveInDirectionComponent
{
    public event Action OnStarted
    {
        add { _engine.OnStartMove += value; }
        remove { _engine.OnStartMove -= value; }
    }

    public event Action OnStopped
    {
        add { _engine.OnStopMove += value; }
        remove { _engine.OnStopMove -= value; }
    }

    public bool IsMoving
    {
        get { return _engine.IsMoving; }
    }

    [SerializeField] private MoveInDirectionEngine _engine;

    public void Move(Vector3 direction)
    {
        _engine.Move(direction);
    }
}
