using System;
using System.Collections.Generic;
using UnityEngine;

public class FightEngine : MonoBehaviour
{
    public event Action<FightWihtEnemyOperation> OnStarted;
    public event Action<FightWihtEnemyOperation> OnFinished;
    public event Action<FightWihtEnemyOperation> OnCanceled;

    [SerializeReference] private List <IFigthWithEnemyCondition> _preconditions = new();
    [SerializeReference] private List <IFigthWithEnemyAction> _preactions = new();

    private FightWihtEnemyOperation _operation;
    
    public bool IsFighting 
    {
        get { return _operation != null; }
    }

    public FightWihtEnemyOperation CurrentOperation
    {
        get { return _operation; }
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

    public void FinishFight()
    {
        Debug.Log("FIGHT Finish");

        _operation.IsCompleted = true;
        var operation= _operation;
        _operation = null;

        OnFinished?.Invoke(operation);
    }

    public void CancelFight()
    {
        Debug.Log("Fight CANCEL");

        _operation.IsCompleted = false;
        var operation = _operation;
        _operation = null;

        OnCanceled?.Invoke(operation);
    }
}