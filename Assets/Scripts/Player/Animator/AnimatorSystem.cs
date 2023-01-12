using System;
using UnityEngine;

public class AnimatorSystem : MonoBehaviour
{
    private static readonly int State = Animator.StringToHash("State");

    public event Action<string> OnEventReceived
    {
        add { _eventDispatcher.OnEventReceived += value; }
        remove { _eventDispatcher.OnEventReceived -= value; }
    }

    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorEventDispatcher _eventDispatcher;
    [SerializeField] private AnimatorStateMachine _stateMachine;

    public void SwitchState(AnimatorStateType stateType)
    {
        _animator.SetInteger(State, (int)stateType);
        _stateMachine.SwitchState(stateType);
    }
}
