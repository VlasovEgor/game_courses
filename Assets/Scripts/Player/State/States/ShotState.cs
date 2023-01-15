using UnityEngine;

public class ShotState : Elementary.State
{
    [SerializeField] private EventReceiver _shotReceiver;
    [SerializeField] private Shot _shot;

    public override void Enter()
    {
        _shotReceiver.OnEvent += Shoot;
    }

    public override void Exit()
    {
        _shotReceiver.OnEvent -= Shoot;
    }

    private void Shoot()
    {
        _shot.Shoot();
    }
}
