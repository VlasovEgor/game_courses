using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class StandingAgent : Agent
{
    [ShowInInspector, ReadOnly]
    private IEntity _unit;

    private float _stoppingTime = 0;

    private Coroutine _stoppingCoroutine;

    [Button]
    public void SetStoppingTime(float time)
    {
        _stoppingTime = time;
    }

    [Button]
    public void SetUnit(IEntity unit)
    {
        _unit = unit;
    }

    protected override void OnStart()
    {
        _stoppingCoroutine = StartCoroutine(StoppingRoutine());
    }

    protected override void OnStop()
    {
        if (_stoppingCoroutine != null)
        {
            StopCoroutine(_stoppingCoroutine);
            _stoppingCoroutine = null;
        }
    }

    private IEnumerator StoppingRoutine()
    {
        Debug.Log("On");
        yield return new WaitForSeconds(_stoppingTime);
        Stop();
        Debug.Log("Off");
    }
}
