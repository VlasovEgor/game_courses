using System;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public event Action ShootStarted;
    public event Action ShootEnded;

    [SerializeField] private EventReceiver _shotReceiver;
    [SerializeField] private TimerBehaviour _countdown;
    [SerializeField] private ShootEngine _engine;
    [SerializeField] private BoolBehavior _isAttack;

    private void OnEnable()
    {
        _shotReceiver.OnEvent += Shoot;
    }

    private void OnDisable()
    {
        _shotReceiver.OnEvent -= Shoot;
    }

    private void Shoot()
    {
        if (_isAttack.Value)
        {
            return;
        }

        if (_countdown.IsPlaying)
        {
            return;
        }

        _engine.Shoot();
        ShootStarted?.Invoke();
        _isAttack.AssignTrue();
        _countdown.ResetTime();
        _countdown.Play();
    }
}