using System;
using UnityEngine;

public class PlayerStateResolver : StateResolver
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
            _machine.SwitchState(StateType.OnGROUND);
        }
        else
        {
            _machine.SwitchState(StateType.InAIR);
        }
    }

    private void CheckShoot(bool isShoot)
    {
        if (isShoot == true)
        {
            _machine.SwitchState(StateType.SHOT);
        }
        else
        {
            _machine.SwitchState(StateType.OnGROUND);
        }
    }
}
