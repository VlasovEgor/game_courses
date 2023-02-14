using Sirenix.OdinInspector;
using UnityEngine;

public class MeleeCombatTask : Task
{
    private IEntity _unit;

    private IEntity _target;

    private IFightWithEnemyComponent _combatComponent;


    [Button]
    public void SetUnit(IEntity unit)
    {
        _unit = unit;
        _combatComponent = unit.Get<IFightWithEnemyComponent>();
    }

    [Button]
    public void SetTarget(IEntity target)
    {
        _target = target;
    }

    protected override void Do()
    {
        _combatComponent = _unit.Get<IFightWithEnemyComponent>();
        var combatOperation = new FightWihtEnemyOperation(_target);

        _combatComponent.OnFinished += OnCombatFinished;
        _combatComponent.StartFight(combatOperation);
    }

    protected override void OnCancel()
    {
        var combatComponent = _unit.Get<IFightWithEnemyComponent>();
        combatComponent.OnFinished -= OnCombatFinished;
        combatComponent.StopFight();
    }

    private void OnCombatFinished(FightWihtEnemyOperation operation)
    {
        _combatComponent = _unit.Get<IFightWithEnemyComponent>();
        _combatComponent.OnFinished -= OnCombatFinished;

        var success = operation.IsCompleted;
        Debug.Log($"Is combat successful {success}");
        Return(success);
    }
}
