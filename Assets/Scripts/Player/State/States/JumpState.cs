
using UnityEngine;

public class JumpState : Elementary.State
{
    [SerializeField] private EventReceiver _jumpReceiver;
    [SerializeField] private Jump _jump;
    public override void Enter()
    {
        _jumpReceiver.OnEvent += OnJump;
    }

    public override void Exit() 
    {
        _jumpReceiver.OnEvent -= OnJump;
    }

    private void OnJump()
    {
        _jump.OnJump();
    }
}
