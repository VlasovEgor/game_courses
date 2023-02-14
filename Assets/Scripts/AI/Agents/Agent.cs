using Sirenix.OdinInspector;
using System;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    public event Action OnStarted;

    public event Action OnStopped;

    [ShowInInspector, ReadOnly]
    public bool IsPlaying
    {
        get { return _isPlaying; }
    }

    private bool _isPlaying;

    [Button]
    public void Play()
    {
        if (_isPlaying==true)
        {
            Debug.LogWarning("Agent is already started!");
            return;
        }

        _isPlaying = true;
        OnStart();
        OnStarted?.Invoke();
    }

    [Button]
    public void Stop()
    {
        if (_isPlaying == false)
        {
            Debug.LogWarning("Agent is not started!");
            return;
        }

        _isPlaying = false;
        OnStop();
        OnStopped?.Invoke();
    }

    protected abstract void OnStart();

    protected abstract void OnStop();
}