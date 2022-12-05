using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections;

public sealed class TimerBehaviour : MonoBehaviour
{
    public event Action OnEnded;

    public bool IsPlaying 
    { 
        get { return _timerCoroutine != null; }
    }

    [SerializeField] private float _duration = 3;
    [SerializeField] [ReadOnly] private float _currentTime;

    private Coroutine _timerCoroutine;

    public void Play()
    {
        if (_timerCoroutine == null)
        {
            _timerCoroutine = StartCoroutine(TimerRoutine());
        }
    }

    public void Stop()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }

    public void ResetTime()
    {
        _currentTime = 0;
    }

    private IEnumerator TimerRoutine()
    {
        while (_currentTime<_duration)
        {
            yield return null;
            _currentTime += Time.deltaTime;
        }

        _currentTime = _duration;
        _timerCoroutine = null;
        OnEnded?.Invoke();
    }
}

