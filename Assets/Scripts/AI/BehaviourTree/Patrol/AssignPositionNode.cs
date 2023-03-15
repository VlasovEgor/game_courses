using System.Collections.Generic;

using UnityEngine;



public sealed class AssignPositionNode : BehaviourNode
{
    [SerializeField]
    private Blackboard _blackboard;

    [SerializeField, BlackboardKey]
    private string _waypointsKey;

    [SerializeField, BlackboardKey]
    private string _movePositionKey;

    protected override void Run()
    {
        if (!_blackboard.TryGetVariable(_waypointsKey, out IEnumerator<Vector3> waypoints))
        {
            Return(false);
            return;
        }

        Vector3 targetPosition = waypoints.Current;

        if (_blackboard.HasVariable(_movePositionKey))
        {
            _blackboard.ChangeVariable(_movePositionKey, targetPosition);
        }
        else
        {
            _blackboard.AddVariable(_movePositionKey, targetPosition);
        }

        Return(true);
    }
}
