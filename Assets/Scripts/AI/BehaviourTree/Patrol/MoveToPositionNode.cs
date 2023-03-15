
using UnityEngine;


public sealed class MoveToPositionNode : BehaviourNode, ITaskCallback
{
    [SerializeField]
    private MoveTask _moveTask;

    [Space, SerializeField]
    private Blackboard _blackboard;

    [SerializeField, BlackboardKey]
    private string _unitKey;

    [SerializeField, BlackboardKey]
    private string _stoppingDistanceKey;

    [SerializeField, BlackboardKey]
    private string _targetPositionKey;

    protected override void Run()
    {
        if (!_blackboard.TryGetVariable(_unitKey, out IEntity unit))
        {
            Return(false);
            return;
        }

        if (!_blackboard.TryGetVariable(_stoppingDistanceKey, out float stoppingDistance))
        {
            Return(false);
            return;
        }

        if (!_blackboard.TryGetVariable(_targetPositionKey, out Vector3 movePosition))
        {
            Return(false);
            return;
        }

        _moveTask.SetUnit(unit);
        _moveTask.SetStoppingDistance(stoppingDistance);
        _moveTask.SetTargetPosition(movePosition);
        _moveTask.Do(callback: this);
    }

    protected override void OnAbort()
    {
        _moveTask.Canñel();
    }

    void ITaskCallback.OnComplete(Task task, bool success)
    {
        Return(success);
    }
}