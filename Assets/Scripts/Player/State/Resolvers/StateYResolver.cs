using UnityEngine;

public class StateYResolver : StateResolver
{
    [SerializeField] private Jump _jump;
    [SerializeField] private BoolBehavior OnGround;

    protected override void OnEnable()
    {
        _jump.Jumped += OnJumped;
        _jump.Lended += OnLended;
    }

    protected override void OnDisable()
    {
        _jump.Jumped -= OnJumped;
        _jump.Lended -= OnLended;
    }

    private void OnJumped()
    {
        OnGround.AssignFalse();
    }

    private void OnLended()
    {
        OnGround.AssignTrue();
    }
}
