using UnityEngine;

public sealed class SequenceNode : BehaviourNode, BehaviourNode.ICallback
{
    [SerializeField]
    private BehaviourNode[] _children;

    private BehaviourNode _currentNode;

    private int _pointer;

    protected override void Run()
    {
        if (_children.Length == 0)
        {
            Return(true);
            return;
        }

        _pointer = 0;
        _currentNode = _children[0];
        _currentNode.Run(callback: this);
    }

    void ICallback.Invoke(BehaviourNode node, bool success)
    {
        if (!success)
        {
            _currentNode = null;
            Return(false);
            return;
        }

        if (_pointer + 1 >= _children.Length)
        {
            _currentNode = null;
            Return(true);
            return;
        }

        _pointer++;
        _currentNode = _children[_pointer];
        _currentNode.Run(callback: this);
    }

    protected override void OnAbort()
    {
        if (_currentNode != null && _currentNode.IsRunning)
        {
            _currentNode.Abort();
        }
    }
}
