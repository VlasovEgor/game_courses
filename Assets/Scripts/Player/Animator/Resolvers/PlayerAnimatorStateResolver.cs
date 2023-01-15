using UnityEngine;

public class PlayerAnimatorStateResolver : AnimatorStateResolver
{
    [SerializeField] private BoolBehavior OnGround;
    [SerializeField] private BoolBehavior OnShooting;
    [SerializeField] private Shot _shot;


    protected override void OnEnable()
    {
        OnGround.OnValueChanged += CheckingPosition;
        OnShooting.OnValueChanged += CheckShoot;
    }

    protected override void OnDisable()
    {
        OnGround.OnValueChanged -= CheckingPosition;
    }

    private void CheckingPosition(bool isGround)
    {
        if (isGround == true)
        {
           // _animator.SwitchState(AnimatorStateType.OnGROUND);
        }
        else
        {
            //_animator.SwitchState(AnimatorStateType.InAIR);
        }
    }

    private void CheckShoot(bool isShoot)
    {
        if (isShoot == true)
        {
            _animator.SwitchState(AnimatorStateType.SHOT);
        }
        else
        {
           // _animator.SwitchState(AnimatorStateType.OnGROUND);
        }
    }
}
