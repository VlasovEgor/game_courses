using System;
using System.Collections.Generic;
using UnityEngine;

public class FightEngine : MonoBehaviour
{
    public event Action<FightWihtEnemyOperation> OnStarted;
    public event Action<FightWihtEnemyOperation> OnFinished;

    [SerializeField] private IntEventReceiver _attack;
    [SerializeField] private BoolBehavior _attackBehavior;

    [SerializeReference] private List< IFigthWithEnemyCondition > _preconditions = new();
    [SerializeReference] private List<IFigthWithEnemyAction> _preactions = new();

    private TakeDamageComponent _enemyTakeDamageComponent;
    private DeathComponent _enemyDeathComponent;

    private FightWihtEnemyOperation _operation;

    public bool IsFighting 
    {
        get { return _operation != null; }
    }

    public bool CanFight(FightWihtEnemyOperation operation)
    {   
        if(IsFighting==true)
        {
            return false;
        }

        for (int i = 0; i < _preconditions.Count; i++)
        {
            var condition = _preconditions[i];
            if(condition.IsTrue(operation) ==false)
            {
                return false;
            }
        }

        return true;
    }

    public void StartFight(FightWihtEnemyOperation operation)
    {
        if(CanFight(operation) == false)
        {
            return;
        }

        DoPreactions(operation);

        _operation = operation;
       
        _enemyTakeDamageComponent = operation.TargetEnemy.Get<TakeDamageComponent>();
        _enemyDeathComponent = operation.TargetEnemy.Get<DeathComponent>();

        _attack.OnEvent += Fight;
        _enemyDeathComponent.OnDeathReceived += StopFight;

        _attackBehavior.AssignTrue();
        Debug.Log("Start FIGHT");

        OnStarted?.Invoke(operation);
    }

    private void DoPreactions(FightWihtEnemyOperation operation)
    {
        for (int i = 0; i < _preactions.Count; i++)
        {
            var action = _preactions[i];
            action.Do(operation);
        }
    }

    public void Fight(int damage)
    {
        Debug.Log(" FIGHT");
        
        _enemyTakeDamageComponent.TakeDamage(damage);
    }

    public void StopFight()
    {
        Debug.Log("Stop FIGHT");

        _attack.OnEvent -= Fight;
        _enemyDeathComponent.OnDeathReceived -= StopFight;

        _operation.IsCompleted = true;
        var operation= _operation;

        _operation = null;

        _attackBehavior.AssignFalse();
        OnFinished?.Invoke(operation);
    }

    public void CanselFight()
    {
        Debug.Log("Fight CANSEL");

        _attack.OnEvent -= Fight;
        _enemyDeathComponent.OnDeathReceived -= StopFight;

        _operation.IsCompleted = false;
        var operation = _operation;

        _operation = null;

        _attackBehavior.AssignFalse();
        OnFinished?.Invoke(operation);
    }
}