using UnityEngine;

public class HandsAnimatorStateResolver : AnimatorStateResolver
{
    [SerializeField] private Shot _shot;

    protected override void OnEnable()
    {
        _shot.ShootStarted += OnShootStarted;
        _shot.ShootEnded += OnShootEnded;
    }

    protected override void OnDisable()
    {
        _shot.ShootStarted -= OnShootStarted;
        _shot.ShootEnded -= OnShootEnded;
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
