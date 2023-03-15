using System;
using UnityEngine;

public sealed class BehaviourTree : BehaviourNode, BehaviourNode.ICallback
{
    public event Action OnStarted;

    public event Action<bool> OnFinished;

    public event Action OnAborted;

    [SerializeField]
    private BehaviourNode _root;

    [Space]
    [SerializeField]
    private bool _runOnStart;

    [SerializeField]
    private bool _loop;

    private void Start()
    {
        if (_runOnStart)
        {
            Run(null);
        }
    }

    private void FixedUpdate()
    {
        if (_loop && !IsRunning)
        {
            Run(null);
        }
    }

    protected override void Run()
    {
        OnStarted?.Invoke();
        _root.Run(this);
    }

    protected override void OnAbort()
    {
        if (_root.IsRunning)
        {
            _root.Abort();
        }

        OnAborted?.Invoke();
    }

    void ICallback.Invoke(BehaviourNode node, bool success)
    {
        Return(success);
        OnFinished?.Invoke(success);
    }
}