using System;
using UnityEngine;

public class AnimatorSystem : MonoBehaviour
{
    private static readonly int BaseState = Animator.StringToHash("BaseState");
    private static readonly int Handstate = Animator.StringToHash("HandsState");

    public event Action<string> OnEventReceived
    {
        add { _eventDispatcher.OnEventReceived += value; }
        remove { _eventDispatcher.OnEventReceived -= value; }
    }

    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorEventDispatcher _eventDispatcher;

    [SerializeField] private AnimatorBaseStateMachine _baseStateMachine;
    [SerializeField] private AnimatorHandsStateMachine _handsStateMachine;

    public void SwitchBaseState(AnimatorBaseStateType stateType)
    {
        _animator.SetInteger(BaseState, (int)stateType);
        _baseStateMachine.SwitchState(stateType);
    }

    public void SwitchHandsState(AnimatorHandsStateType stateType)
    {
        _animator.SetInteger(Handstate, (int)stateType);
        _handsStateMachine.SwitchState(stateType);
        
    }
}
