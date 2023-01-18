using UnityEngine;

public class ResurrectionEntity : MonoBehaviour
{
    [SerializeField] private TimerBehaviour _timerBehaviour;
    [SerializeField] private BoolBehavior _isDead;
    [SerializeField] private EventReceiver _deathReceiver;
    [SerializeField] private GameObject _visualEntity;
    [SerializeField] private GameObject _colliderEntity;
    [SerializeField] private IntBehaviour _currentHealth;

    private int _health;

    public void OnEnable()
    {
        _health = _currentHealth.Value;
        _deathReceiver.OnEvent += Disabling;
        _timerBehaviour.OnEnded+= Eabling;
    }

    public void OnDisable()
    {
        _deathReceiver.OnEvent -= Disabling;
        _timerBehaviour.OnEnded -= Eabling;
    }

    private void Disabling()
    {
        _visualEntity.SetActive(false);
        _colliderEntity.SetActive(false);
        _timerBehaviour.ResetTime();
        _timerBehaviour.Play();
        _isDead.AssignTrue();
    }

    private void Eabling()
    {
        _visualEntity.SetActive(true);
        _colliderEntity.SetActive(true);
        _isDead.AssignFalse();
        _currentHealth.Value = _health;
    }
}
