using System;
using UnityEngine;

public class MoveInDirectionEngine : MonoBehaviour
{

    public event Action OnStartMove;
    public event Action OnStopMove;

    public bool IsMoving
    {
        get { return _direction != Vector3.zero; }
    }

    public Vector3 Direction
    { 
        get { return _direction; } 
    }

    private bool _finishMove;

    private Vector3 _direction;

    public void Move(Vector3 direction)
    {
        _direction = direction;
        _finishMove = false;
        StartMove();
    }

    private void StartMove()
    {
        OnStartMove?.Invoke();
    }

    private void StopMove()
    {
        OnStopMove?.Invoke();
    }

}