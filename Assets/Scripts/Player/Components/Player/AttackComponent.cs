using System;
using UnityEngine;

public class AttackComponent : MonoBehaviour, IAttackComponent
{
   // [SerializeField] private EventReceiver _attackBegun;
   // [SerializeField] private EventReceiver _attackOver;
    [SerializeField] private IntEventReceiver _attackIsDone;

    public void StartAttack()
    {
       // _attackBegun.Call();
    }

    public void StopAttack()
    {
       // _attackOver.Call();
    }

    public event Action<int> OnAttackIsDone
    {
        add { _attackIsDone.OnEvent += value; }
        remove { _attackIsDone.OnEvent -= value; }
    }
}
