using UnityEngine;

public class AnimatorStateResolver : MonoBehaviour
{
    [SerializeField] private AnimatorSystem _animator;

    [Space]
    [SerializeField] private MoveInDirectionEngine _moveInDirectionEngine;
    [SerializeField] private Jump _jump;
    [SerializeField] private Shot _shot;


    private void OnEnable()
    {
        _moveInDirectionEngine.OnStartMove += OnMoveStarted;
        _moveInDirectionEngine.OnStopMove += OnMoveStoped;

        _jump.Jumped += OnJumped;
        _jump.Lended += OnLended;

        _shot.ShootStarted += OnShootStarted;
        _shot.ShootEnded += OnShootEnded;
    }

    private void OnDisable()
    {
        _moveInDirectionEngine.OnStartMove -= OnMoveStarted;
        _moveInDirectionEngine.OnStopMove -= OnMoveStoped;

        _jump.Jumped -= OnJumped;
        _jump.Lended -= OnLended;

        _shot.ShootStarted -= OnShootStarted;
        _shot.ShootEnded -= OnShootEnded;
    }

    private void OnMoveStarted()
    {
        _animator.SwitchState(AnimatorStateType.RUN);
    }

    private void OnMoveStoped()
    {
        _animator.SwitchState(AnimatorStateType.IDLE);
    }

    private void OnJumped()
    {
        _animator.SwitchState(AnimatorStateType.JUMP); ;
    }

    private void OnLended()
    {
        _animator.SwitchState(AnimatorStateType.IDLE); ;
    }

    private void OnShootStarted()
    {
        _animator.SwitchState(AnimatorStateType.SHOT); ;
    }

    private void OnShootEnded()
    {
        _animator.SwitchState(AnimatorStateType.IDLE); ;
    }
}
