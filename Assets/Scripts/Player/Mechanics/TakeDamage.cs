using Elementary;
using UnityEngine;


public sealed class TakeDamage : MonoBehaviour
{
    [SerializeField] private IntEventReceiver _takeDamageReceiver;
    [SerializeField] private IntBehaviour _hitPoints;
    [SerializeField] private FloatBehaviour _takeDamageMultiplier;

    private void OnEnable()
    {
        _takeDamageReceiver.OnEvent += OnDamageTaken;
    }

    private void OnDisable()
    {
        _takeDamageReceiver.OnEvent -= OnDamageTaken;
    }

    private void OnDamageTaken(int damage)
    {
        _hitPoints.Value -= damage * (int)_takeDamageMultiplier.Value;
    }
}

