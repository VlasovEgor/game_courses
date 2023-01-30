using UnityEngine;

public class EnemyControlDeathState : Elementary.State
{
    [SerializeField] private FightEngine _currentEngine;

    private DeathComponent _enemyDeathComponent;

    public override void Enter()
    {
        _enemyDeathComponent = _currentEngine.CurrentOperation.TargetEnemy.Get<DeathComponent>();
        _enemyDeathComponent.OnDeathReceived += FinishFight;
    }
    public override void Exit()
    {
        _enemyDeathComponent.OnDeathReceived -= FinishFight;
    }

    private void FinishFight()
    {
        _currentEngine.FinishFight();
    }
}
