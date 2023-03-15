using System.Collections.Generic;
using Entities;
using UnityEngine;


public sealed class BlackboardInstaller : MonoBehaviour
{
    [SerializeField]
    private Blackboard _blackboard;

    [Space]
    [BlackboardKey]
    [SerializeField]
    private string _unitKey;

    [SerializeField]
    private Entity _unitEntity;

    [Space]
    [BlackboardKey]
    [SerializeField]
    private string _stoppingDistanceKey;

    [SerializeField]
    private float _stoppingDistance;

    [Space]
    [BlackboardKey]
    [SerializeField]
    private string _waypointsKey;

    [SerializeField]
    private WaypointsPath _waypoints;

    [Space]
    [SerializeField]
    [BlackboardKey]
    private string _patrolDelayKey;

    [SerializeField]
    private float _patrolDelay = 1.0f;

    private void Awake()
    {
        _blackboard.AddVariable(_unitKey, _unitEntity);
        _blackboard.AddVariable(_stoppingDistanceKey, _stoppingDistance);
        _blackboard.AddVariable(_waypointsKey, CreateWaypointsIterator());
        _blackboard.AddVariable(_patrolDelayKey, _patrolDelay);
    }

    private IEnumerator<Vector3> CreateWaypointsIterator()
    {
        IEnumerator<Vector3> iterator;
        Vector3[] waypoints = _waypoints.GetPositionPoints().ToArray();
        iterator = IteratorFactory.CreateIterator(IteratorMode.CIRCLE, waypoints);
        return iterator;
    }
}
