using UnityEngine;

public class MeleeAttackState : Elementary.State
{
    [SerializeField] private FightEngine _currentEngine;
    [SerializeField] private IntEventReceiver _dealDamageEvent;

    private TakeDamageComponent _enemyTakeDamageComponent;
    
    public override void Enter()
    {
        _dealDamageEvent.OnEvent += Fight;
        _enemyTakeDamageComponent = _currentEngine.CurrentOperation.TargetEnemy.Get<TakeDamageComponent>();
    }

    public override void Exit()
    {
        _dealDamageEvent.OnEvent -= Fight;
    }

    public void Fight(int damage)
    {
        Debug.Log(" FIGHT");
        _enemyTakeDamageComponent.TakeDamage(damage);
    }
}
