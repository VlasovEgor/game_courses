using System;
using UnityEngine;

public class BaseAnimatorStateResolver : AnimatorStateResolver
{
    [SerializeField] private MoveInDirectionEngine _moveInDirectionEngine;
    [SerializeField] private BoolBehavior OnJump;
  

    protected override void OnEnable()
    {
        _moveInDirectionEngine.OnStartMove += OnMoveStarted;
        _moveInDirectionEngine.OnStopMove += OnMoveStoped;

        OnJump.OnValueChanged += CheckingPosition;
    }

    protected override void OnDisable()
    {
        _moveInDirectionEngine.OnStartMove -= OnMoveStarted;
        _moveInDirectionEngine.OnStopMove -= OnMoveStoped;


        OnJump.OnValueChanged -= CheckingPosition;
    }

    private void OnMoveStarted()
    {   
        if(OnJump.Value==false)
        {
            _animator.SwitchState(AnimatorStateType.RUN);
        }  
    }

    private void OnMoveStoped()
    {
        _animator.SwitchState(AnimatorStateType.IDLE);
    }

    private void CheckingPosition(bool obj)
    {
        if (obj == true)
        {
            _animator.SwitchState(AnimatorStateType.JUMP);
        }
        else
        {
            _animator.SwitchState(AnimatorStateType.IDLE);
        }
    }
}
