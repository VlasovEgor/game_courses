using UnityEngine;

public class StateResolver : MonoBehaviour
{
    [SerializeField] private StateMachine _machine;

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
        _machine.SwitchState(StateType.RUN);
    }

    private void OnMoveStoped()
    {
        _machine.SwitchState(StateType.IDLE);
    }

    private void OnJumped()
    {
        _machine.SwitchState(StateType.JUMP); ;
    }

    private void OnLended()
    {
        _machine.SwitchState(StateType.IDLE); ;
    }

    private void OnShootStarted()
    {
        _machine.SwitchState(StateType.SHOT); ;
    }

    private void OnShootEnded()
    {
        _machine.SwitchState(StateType.IDLE); ;
    }
}