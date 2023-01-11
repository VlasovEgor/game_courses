

using UnityEngine;

public class AnimationState :Elementary.State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _animationIndex;

    private static readonly int State = Animator.StringToHash("State");

    public override void Enter()
    {
        _animator.SetInteger(State, _animationIndex);
    }
}
