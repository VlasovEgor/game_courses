using System;
using UnityEngine;

public class FIghtWithEnemyComponent : MonoBehaviour, IFIghtWithEnemyComponent
{
    public event Action<FightWihtEnemyOperation> OnStarted
    {
        add { _fightEngine.OnStarted += value; }
        remove { _fightEngine.OnStarted -= value; }
    }

    public event Action<FightWihtEnemyOperation> OnFinished
    {
        add { _fightEngine.OnFinished += value; }
        remove { _fightEngine.OnFinished -= value; }
    }

    [SerializeField] private FightEngine _fightEngine;

    public bool IsFighting { get; }

    public bool CanFight(FightWihtEnemyOperation operation)
    {
       return _fightEngine.CanFight(operation);
    }

    public void StartFight(FightWihtEnemyOperation operation)
    {
        _fightEngine.StartFight(operation);
    }

    public void Fight(int damage)
    {
        _fightEngine.Fight(damage);
    }

    public void StopFight()
    {
        _fightEngine.StopFight();
    }

    public void CanselFight()
    {
        _fightEngine.CanselFight();
    }
}
