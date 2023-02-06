using UnityEngine;

public class Attack : MonoBehaviour
{
   [SerializeField] private EventReceiver _attackReceiver;
   [SerializeField] private TimerBehaviour _countdown;

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
        if (_countdown.IsPlaying)
        {
            return;
        }

        _countdown.ResetTime();
        _countdown.Play();
    }
}
