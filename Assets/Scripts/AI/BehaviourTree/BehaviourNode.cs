using Sirenix.OdinInspector;
using UnityEngine;


public abstract class BehaviourNode : MonoBehaviour
{
    [ShowInInspector, ReadOnly]
    public bool IsRunning
    {
        get { return _isRunning; }
    }

    private bool _isRunning;

    private ICallback _callback;

    [Button]
    public void Run(ICallback callback)
    {
        if (_isRunning)
        {
            Debug.LogWarning($"Node {name} is already running!");
            return;
        }

        _callback = callback;
        _isRunning = true;
        Run();
    }

    [Button]
    public void Abort()
    {
        if (_isRunning)
        {
            _callback = null;
            _isRunning = false;
            OnAbort();
        }
    }

    protected void Return(bool success)
    {
        if (!_isRunning)
        {
            return;
        }

        _isRunning = false;
        Debug.Log($"Return node {name}: {success}");

        var callback = _callback;
        if (callback != null)
        {
            _callback = null;
            callback.Invoke(this, success);
        }
    }

    protected abstract void Run();

    protected virtual void OnAbort()
    {
    }

    public interface ICallback
    {
        void Invoke(BehaviourNode node, bool success);
    }
}