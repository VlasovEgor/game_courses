using UnityEngine;

public class StateXZResolver : StateResolver
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
        _machine.SwitchState(StateType.RUN);
    }

    private void OnMoveStoped()
    {
        _machine.SwitchState(StateType.IDLE);
    }
}
