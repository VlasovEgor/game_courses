using UnityEngine;

public sealed class SelectorNode : BehaviourNode, BehaviourNode.ICallback
{
    [SerializeField]
    private BehaviourNode[] _children;

    private BehaviourNode _currentChild;

    private int _pointer;

    protected override void Run()
    {
        if (_children.Length <= 0)
        {
            Return(false);
            return;
        }

        _pointer = 0;
        _currentChild = _children[0];
        _currentChild.Run(callback: this);
    }

    void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool result)
    {
        if (result)
        {
            _currentChild = null;
            Return(true);
            return;
        }

        if (_pointer + 1 >= _children.Length)
        {
            _currentChild = null;
            Return(false);
            return;
        }

        _pointer++;
        _currentChild = _children[_pointer];
        _currentChild.Run(callback: this);
    }

    protected override void OnAbort()
    {
        if (_currentChild != null && _currentChild.IsRunning)
        {
            _currentChild.Abort();
        }
    }
}
