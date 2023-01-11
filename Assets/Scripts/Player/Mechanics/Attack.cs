using UnityEngine;

public class Attack : MonoBehaviour
{
   [SerializeField] private EventReceiver _attackReceiver;
   [SerializeField] private TimerBehaviour _countdown;
   [SerializeField] private IntBehaviour _damage;
   [SerializeField] private BoolBehavior _isAttack;

    private void OnEnable()
    {
        _attackReceiver.OnEvent += OnRequiestAttack;
    }

    private void OnDisable()
    {
        _attackReceiver.OnEvent -= OnRequiestAttack;
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

        _isAttack.AssignTrue();
        _countdown.ResetTime();
        _countdown.Play();
    }
}
