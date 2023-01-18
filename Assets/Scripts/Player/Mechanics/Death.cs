using UnityEngine;


public class Death : MonoBehaviour
{
    [SerializeField] private EventReceiver _deathReceiver;
    [SerializeField] private IntBehaviour _healthPoints;

    private void OnEnable()
    {
        _healthPoints.OnValueChanged += OnHitPointsChanged;
    }

    private void OnDisable()
    {
        _healthPoints.OnValueChanged -= OnHitPointsChanged;
    }

    private void OnHitPointsChanged(int newHitPoints)
    {
        if (newHitPoints <= 0)
        {
            _deathReceiver.Call();
        }
    }
}

