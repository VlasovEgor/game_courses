using System.Collections.Generic;
using UnityEngine;



public sealed class NextWaypointNode : BehaviourNode
{
    [SerializeField]
    private Blackboard _blackboard;

    [SerializeField, BlackboardKey]
    private string _waypointsKey;

    protected override void Run()
    {
        if (!_blackboard.TryGetVariable(_waypointsKey, out IEnumerator<Vector3> waypoints))
        {
            Return(false);
            return;
        }

        waypoints.MoveNext();
        Return(true);
    }
}
