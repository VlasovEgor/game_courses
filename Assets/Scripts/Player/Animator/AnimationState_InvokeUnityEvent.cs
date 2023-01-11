using UnityEngine;
using UnityEngine.Events;

public class AnimationState_InvokeUnityEvent : Elementary.State
{   
    [SerializeField] private AnimatorSystem _animatorSystem;
    [SerializeField] private string _animationEventID;
    [Space]
    [SerializeField] private UnityEvent _unityEvent;


    public override void Enter()
    {
        _animatorSystem.OnEventReceived += OnEvent;
    }

    public override void Exit() 
    {
        _animatorSystem.OnEventReceived -= OnEvent;
    }

    private void OnEvent(string eventID)
    {
        if (eventID==_animationEventID)
        {
            _unityEvent.Invoke();
        }       
    }
}
