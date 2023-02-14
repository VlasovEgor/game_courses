using System;
using UnityEngine;

public class FightWithEnemyComponent : MonoBehaviour,IFightWithEnemyComponent
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

    public event Action<FightWihtEnemyOperation> OnCanceled
    {
        add { _fightEngine.OnCanceled += value; }
        remove { _fightEngine.OnCanceled -= value; }
    }

    public bool IsFighting { get; }

    public bool CanFight(FightWihtEnemyOperation operation)
    {
        return _fightEngine.CanFight(operation);
    }

    public void StartFight(FightWihtEnemyOperation operation)
    {
        _fightEngine.StartFight(operation);
    }

    public void StopFight()
    {
        _fightEngine.FinishFight();
    }

    public void CancelFight()
    {
        _fightEngine.CancelFight();
    }
}
