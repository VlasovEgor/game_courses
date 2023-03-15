using System.Collections;
using UnityEngine;

public sealed class FollowTargetNode : BehaviourNode, ITaskCallback
{
    [SerializeField]
    private MoveTask _moveTask;

    [Space]
    [SerializeField]
    private Blackboard _blackboard;

    [BlackboardKey]
    [SerializeField]
    private string _unitKey;

    [BlackboardKey]
    [SerializeField]
    private string _targetKey;

    [BlackboardKey]
    [SerializeField]
    private string _stoppingDistanceKey;

    private IGetPositionComponent _targetComponent;

    private Coroutine _updateCoroutine;

    protected override void Run()
    {
        if (!_blackboard.TryGetVariable(_unitKey, out IEntity unit))
        {
            Return(false);
            return;
        }

        if (!_blackboard.TryGetVariable(_targetKey, out IEntity target))
        {
            Return(false);
            return;
        }

        if (!_blackboard.TryGetVariable(_stoppingDistanceKey, out float stoppingDistance))
        {
            Return(false);
            return;
        }

        _targetComponent = target.Get<IGetPositionComponent>();
        _updateCoroutine = StartCoroutine(UpdatePositionRoutine());

        _moveTask.SetUnit(unit);
        _moveTask.SetStoppingDistance(stoppingDistance);
        _moveTask.Do(callback: this);
    }

    private IEnumerator UpdatePositionRoutine()
    {
        var period = new WaitForFixedUpdate();
        while (true)
        {
            _moveTask.SetTargetPosition(_targetComponent.GetPosition());
            yield return period;
        }
    }

    void ITaskCallback.OnComplete(Task task, bool success)
    {
        if (_updateCoroutine != null)
        {
            StopCoroutine(_updateCoroutine);
            _updateCoroutine = null;
        }

        Return(true);
    }

    protected override void OnAbort()
    {
        if (_updateCoroutine != null)
        {
            StopCoroutine(_updateCoroutine);
            _updateCoroutine = null;
        }

        _moveTask.Canñel();
    }
}
