using UnityEngine;

public class XZAnimatorStateResolver : AnimatorStateResolver
{
    [SerializeField] private MoveInDirectionEngine _moveInDirectionEngine;

    protected override void OnEnable()
    {
        _moveInDirectionEngine.OnStartMove += OnMoveStarted;
        _moveInDirectionEngine.OnStopMove += OnMoveStoped;
    }

    protected override void OnDisable()
    {
        _moveInDirectionEngine.OnStartMove -= OnMoveStarted;
        _moveInDirectionEngine.OnStopMove -= OnMoveStoped;
    }

    private void OnMoveStarted()
    {
      //  _animator.SwitchState(AnimatorStateType.RUN);
    }

    private void OnMoveStoped()
    {
       // _animator.SwitchState(AnimatorStateType.IDLE);
    }
}
