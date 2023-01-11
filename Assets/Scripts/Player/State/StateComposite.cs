using System.Collections.Generic;
using UnityEngine;

public class StateComposite : State
{
    [SerializeField]
    private List<State> _stateComponents;

    public override void Enter()
    {
        for (int i = 0, count = _stateComponents.Count; i < count; i++)
        {
            var state = _stateComponents[i];
            state.Enter();
        }
    }

    public override void Exit()
    {
        for (int i = 0, count = _stateComponents.Count; i < count; i++)
        {
            var state = _stateComponents[i];
            state.Exit();
        }
    }

    public void AddState(State state)
    {
        _stateComponents.Add(state);
    }

    public void RemoveState(State state)
    {
        _stateComponents.Remove(state);
    }
}
