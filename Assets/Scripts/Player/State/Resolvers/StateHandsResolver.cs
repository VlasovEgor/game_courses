using UnityEngine;

public class StateHandsResolver : StateResolver
{
    [SerializeField] private Shot _shot;

    protected override void OnEnable()
    {
        _shot.ShootStarted += OnShootStarted;
        _shot.ShootEnded += OnShootEnded;
    }

    protected  override void OnDisable()
    {
        _shot.ShootStarted -= OnShootStarted;
        _shot.ShootEnded -= OnShootEnded;
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
