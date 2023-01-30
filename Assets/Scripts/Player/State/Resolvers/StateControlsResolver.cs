using UnityEngine;

public class StateControlsResolver : MonoBehaviour
{
    [SerializeField] protected ControlsStateMachine _machine;
    [SerializeField] private FightEngine _fightEngine;

    private void OnEnable()
    {
        _fightEngine.OnStarted += OnFightStarted;
        _fightEngine.OnFinished += OnFightFinished;
        _fightEngine.OnCanceled += OnFightCanceled;
    }

    private void OnDisable()
    {
        _fightEngine.OnStarted -= OnFightStarted;
        _fightEngine.OnFinished -= OnFightFinished;
        _fightEngine.OnCanceled -= OnFightCanceled;
    }

    private void OnFightStarted(FightWihtEnemyOperation obj)
    {
        _machine.SwitchState(ControlsStateType.ENEMY_CONTROL_DEATH);
    }

    private void OnFightFinished(FightWihtEnemyOperation obj)
    {
        _machine.SwitchState(ControlsStateType.IDLE);
    }

    private void OnFightCanceled(FightWihtEnemyOperation obj)
    {
        _machine.SwitchState(ControlsStateType.IDLE);
    }
}
