using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class MeleeCombatAgent : Agent
{
    [ShowInInspector, ReadOnly]
    private IEntity _unit;

    [ShowInInspector, ReadOnly]
    private IEntity _target;

    private FightWithEnemyComponent _combatComponent;

    private Coroutine _combatCoroutine;

    [Button]
    public void SetUnit(IEntity unit)
    {
        if (_unit != null)
        {
            _combatComponent.StopFight();
        }

        _unit = unit;
        _combatComponent = unit?.Get<FightWithEnemyComponent>();
    }

    [Button]
    public void SetTarget(IEntity target)
    {
        if (_unit != null)
        {
            _combatComponent.StopFight();
        }

        _target = target;
    }

    protected override void OnStart()
    {
        _combatCoroutine = StartCoroutine(CombatRoutine());
    }

    protected override void OnStop()
    {
        if (_combatCoroutine != null)
        {
            StopCoroutine(_combatCoroutine);
            _combatCoroutine = null;
        }

        if (_combatComponent.IsFighting == true)
        {
            _combatComponent.StopFight();
        }
    }

    private IEnumerator CombatRoutine()
    {
        var period = new WaitForFixedUpdate();

        while (true)
        {
            if (_unit != null && _target != null)
            {
                StartCombat();
            }

            yield return period;
        }
    }

    private void StartCombat()
    {
        if (_combatComponent.IsFighting)
        {
            return;
        }

        var combatOperation = new FightWihtEnemyOperation(_target);
        _combatComponent.StartFight(combatOperation);
    }
}