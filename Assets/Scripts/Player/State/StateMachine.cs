using Elementary;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine: Elementary.State
{
    [SerializeField] private bool _enterOnEnable;
    [SerializeField] private bool _exitOnDisable;
    [SerializeField] private List<StateHolder> _states;
    [SerializeField] private StateType _currentStateType;

    private Elementary.State _currentState;

    private void OnEnable()
    {
        if (_enterOnEnable)
        {
            Enter();
        }
    }

    private void OnDisable()
    {
        if (_exitOnDisable)
        {
            Exit();
        }
    }

    public StateType CurrentState
    { 
        get 
        { 
            return _currentStateType;
        } 
    }

    public override void Enter()
    {
        if (_currentState == null)
        {
            _currentState = FindState(_currentStateType);
            _currentState.Enter();
        }
    }

    public override void Exit()
    {
        if (_currentState != null)
        {
            _currentState.Exit();
            _currentState = null;
        }
    }

    public void SwitchState(StateType stateType)
    {
        Exit();
        _currentStateType = stateType;
        Enter();
    }

    private Elementary.State FindState(StateType stateType)
    {
        for (int i = 0; i < _states.Count; i++)
        {
            StateHolder holder = _states[i];
            if (holder.Type == stateType)
            {
                return holder.State;
            }
        }

        throw new Exception($"State {stateType} is not found");
    }

    [Serializable]
    private struct StateHolder
    {
        [SerializeField] public StateType Type;

        [SerializeField] public Elementary.State State;
    }

}
