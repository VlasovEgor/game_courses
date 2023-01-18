using UnityEngine;

public class PlayerAnimatorStateResolver : AnimatorStateResolver
{
    [SerializeField] private GroundBehaviour _groundBehaviour;
    [SerializeField] private MoveInDirectionEngine _moveEngine;
    [SerializeField] private BoolBehavior _isShot;
    [SerializeField] private Shot _shot;

    private void Update()
    {
        if (_groundBehaviour.IsGrounded == true)
        {
            if (_moveEngine.IsMoving == true)
            {
                _animator.SwitchBaseState(AnimatorBaseStateType.RUN);
            }
            else
            {
                _animator.SwitchBaseState(AnimatorBaseStateType.IDLE);
            }
        }
        else
        {
            _animator.SwitchBaseState(AnimatorBaseStateType.JUMP);
        }

       if(_isShot.Value==true)
       {
           _animator.SwitchHandsState(AnimatorHandsStateType.SHOT);
       }
       else
       {
            _animator.SwitchHandsState(AnimatorHandsStateType.IDLE);
       }
    }

    
}
