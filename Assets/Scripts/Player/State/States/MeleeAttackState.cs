using UnityEngine;

public class MeleeAttackState : Elementary.State
{
    [SerializeField] private FightEngine _currentEngine;

    [SerializeField] private TimerBehaviour _countdown;
    [SerializeField] private IntBehaviour _damage;

    private TakeDamageComponent _enemyTakeDamageComponent;

    private void Awake()
    {
        enabled = false;
    }

    public override void Enter()
    {
        enabled = true;
        _enemyTakeDamageComponent = _currentEngine.CurrentOperation.TargetEnemy.Get<TakeDamageComponent>();
    }

    public override void Exit()
    {
        enabled = false;
    }

    private void Update()
    {
        TryAttack();
    }

    private void TryAttack()
    {
        if (_currentEngine.IsFighting == true)
        {
            OnRequiestAttack();
        }
    }

    private void OnRequiestAttack()
    {
        if (_countdown.IsPlaying)
        {
            return;
        }

        _enemyTakeDamageComponent.TakeDamage(_damage.Value);

        _countdown.ResetTime();
        _countdown.Play();
        Debug.Log("FIGHT");
    }
}