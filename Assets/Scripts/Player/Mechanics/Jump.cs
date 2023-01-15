using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public event Action Lended;
    public event Action Jumped;

    [SerializeField] private IntBehaviour _jumpPower;
    [SerializeField] private EventReceiver _jumpReceiver;
    [SerializeField] private GroundBehaviour _grounded;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BoolBehavior _isJump;

    private void OnEnable()
    {
        _jumpReceiver.OnEvent += OnJump;
    }

    private void OnDisable()
    {
        _jumpReceiver.OnEvent -= OnJump;
    }

    private void Update()
    {
        CheckingPosition();
    }

    public void OnJump()
    {
        if (_grounded.IsGrounded == true)
        {
            _rigidbody.velocity = new Vector3(0, _jumpPower.Value, 0);
            Jumped?.Invoke();
            _isJump.AssignTrue();
        }
    }

    private void CheckingPosition()
    {
        if (_grounded.IsGrounded == true)
        {
            _isJump.AssignFalse();
        }
        else
        {
            _isJump.AssignTrue();
        }
    }

   // private void OnLended()
   // {
   //     Lended?.Invoke();
   //     _isJump.AssignFalse();
   // }
}
