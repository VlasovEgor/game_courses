using UnityEngine;

public class Attack : MonoBehaviour
{
    public IntEventReceiver Hit;

    [SerializeField] private TimerBehaviour _countdown;
    [SerializeField] private IntBehaviour _damage;
    [SerializeField] private BoolBehavior _isAttack;
    [SerializeField] private BoolBehavior _canAttack;


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
        if (_canAttack.Value == true)
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

        Hit.Call(_damage.Value);
        _isAttack.AssignTrue();
        _countdown.ResetTime();
        _countdown.Play();

    }
}
