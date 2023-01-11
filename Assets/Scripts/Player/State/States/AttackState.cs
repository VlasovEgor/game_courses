

using UnityEngine;

public class AttackState : Elementary.State
{
    [SerializeField] private Shot _shot;
    [SerializeField] private ShootEngine _shootEngine;

    public override void Enter()
    {
        _shot.ShootStarted += Shoot;
    }

    public override void Exit() 
    {
        _shot.ShootStarted -= Shoot;
    }

    private void Shoot()
    {
        _shootEngine.Shoot();
    }
}
