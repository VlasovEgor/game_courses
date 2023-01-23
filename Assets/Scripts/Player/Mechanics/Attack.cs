using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private IntEventReceiver _hit;

    [SerializeField] private TimerBehaviour _countdown;
    [SerializeField] private IntBehaviour _damage;
    [SerializeField] private BoolBehavior _isAttack;
    [SerializeField] private FightEngine _fightEngine;


    private void Update()
    {
        if (_countdown.IsPlaying == false)
        {
            _isAttack.AssignFalse();
        }

        TryAttack();
    }

    private void TryAttack()
    {
        if (_fightEngine.IsFighting == true)
        {
            OnRequiestAttack();
        }
    }

    private void OnRequiestAttack()
    {
        if (_isAttack.Value)
        {
            return;
        }

        if (_countdown.IsPlaying)
        {
            return;
        }

        _hit.Call(_damage.Value);
        _isAttack.AssignTrue();
        _countdown.ResetTime();
        _countdown.Play();

    }
}
