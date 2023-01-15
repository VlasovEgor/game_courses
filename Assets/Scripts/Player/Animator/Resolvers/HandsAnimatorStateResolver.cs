using UnityEngine;

public class HandsAnimatorStateResolver : AnimatorStateResolver
{
    [SerializeField] private Shot _shot;
    [SerializeField] private BoolBehavior _shotBehavior;

    protected override void OnEnable()
    {
        //_shot.ShootStarted += OnShootStarted;
        //_shot.ShootEnded += OnShootEnded;
        _shotBehavior.OnValueChanged += CheckShoot;
    }

    protected override void OnDisable()
    {
        //_shot.ShootStarted -= OnShootStarted;
        //_shot.ShootEnded -= OnShootEnded;
        _shotBehavior.OnValueChanged -= CheckShoot;
    }

    private void OnShootStarted()
    {
        _animator.SwitchState(AnimatorStateType.SHOT); ;
    }

    private void OnShootEnded()
    {
        _animator.SwitchState(AnimatorStateType.IDLE); ;
    }

    private void CheckShoot(bool obj)
    {
        if (obj == true)
        {
            _animator.SwitchState(AnimatorStateType.SHOT);
        }
        else
        {
            _animator.SwitchState(AnimatorStateType.IDLE);
        }
    }
}
