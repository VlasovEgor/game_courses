using UnityEngine;

public class ShotState : Elementary.State
{
    [SerializeField] private EventReceiver _shot;
    [SerializeField] private ShootEngine _shootEngine;

    public override void Enter()
    {
        _shot.OnEvent += Shoot;
    }

    public override void Exit()
    {
        _shot.OnEvent -= Shoot;
    }

    private void Shoot()
    {
        _shootEngine.Shoot();
    }
}
