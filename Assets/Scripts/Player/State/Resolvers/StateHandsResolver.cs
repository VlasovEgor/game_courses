using UnityEngine;

public class StateHandsResolver : StateResolver
{
    [SerializeField] private Shot _shot;
    [SerializeField] private FightEngine _fightEngine;

    protected override void OnEnable()
    {
        _shot.IsShot.OnValueChanged += OnShoot;

        _fightEngine.OnStarted += OnFightStarted;
        _fightEngine.OnFinished += OnFightFinished;
        _fightEngine.OnCanceled += OnFightCanceled;
    }

    protected override void OnDisable()
    {
        _shot.IsShot.OnValueChanged += OnShoot;

        _fightEngine.OnStarted -= OnFightStarted;
        _fightEngine.OnFinished -= OnFightFinished;
        _fightEngine.OnCanceled -= OnFightCanceled;
    }

    private void OnShoot(bool isShoot)
    {
        if (isShoot==true)
        {
            _machine.SwitchState(StateType.SHOT);
        }
        else
        {
            _machine.SwitchState(StateType.IDLE);
        }
    }

    private void OnFightStarted(FightWihtEnemyOperation obj)
    {
        _machine.SwitchState(StateType.MELEE_ATTACK);
    }

    private void OnFightFinished(FightWihtEnemyOperation obj)
    {
        _machine.SwitchState(StateType.IDLE);
    }

    private void OnFightCanceled(FightWihtEnemyOperation obj)
    {   
        _machine.SwitchState(StateType.IDLE);
    }
}
