using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public bool IsPlaying
    {
        get { return _isPlaying; }
    }

    private bool _isPlaying;
    private ITaskCallback _callback;

    [Button]
    public void Do(ITaskCallback callback)
    {
        if (_isPlaying == true)
        {
            Debug.LogWarning($"Action {name} is already started");
            return;
        }

        _isPlaying = true;
        _callback = callback;
        Do();
    }

    [Button]
    public void Cansel()
    {
        if (IsPlaying == false)
        {
            return;
        }

        _isPlaying = false;
        _callback = null;
        OnCancel();
    }

    protected virtual void OnCancel()
    {

    }

    protected abstract void Do();

    protected void Return(bool success)
    {
        _isPlaying = false;
        var callback = _callback;
        callback?.OnComplete(this, success);
        _callback = null;
    }

}
