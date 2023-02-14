using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class MoveAgent : Agent
{
    [ShowInInspector, ReadOnly]
    private IEntity _unit;

    [ShowInInspector, ReadOnly]
    private float _stoppingDistance;

    [ShowInInspector, ReadOnly]
    private Vector3 _targetPosiiton;

    private IGetPositionComponent _positionComponent;

    private IMoveInDirectionComponent _moveComponent;

    private Coroutine _moveCoroutine;

    [Button]
    public void SetTargetPosiiton(Transform point)
    {
        _targetPosiiton = point.position;
    }

    [Button]
    public void SetTargetPosiiton(Vector3 position)
    {
        _targetPosiiton = position;
    }

    [Button]
    public void SetStoppingDistance(float stoppingDistance)
    {
        _stoppingDistance = stoppingDistance;
    }

    [Button]
    public void SetUnit(IEntity unit)
    {
        _unit = unit;
        _positionComponent = unit?.Get<IGetPositionComponent>();
        _moveComponent = unit?.Get<IMoveInDirectionComponent>();
    }

    protected override void OnStart()
    {
        _moveCoroutine = StartCoroutine(MoveRoutine());
    }

    protected override void OnStop()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    private IEnumerator MoveRoutine()
    {
        var period = new WaitForFixedUpdate();

        while (true)
        {
            if (_unit != null)
            {
                DoMove();
            }

            yield return period;
        }
    }

    private void DoMove()
    {
        var myPosition = _positionComponent.GetPosition();
        var distanceVector = _targetPosiiton - myPosition;

        var isReached = distanceVector.sqrMagnitude <= _stoppingDistance * _stoppingDistance;
        if (isReached == false)
        {
            var moveDirection = distanceVector.normalized;
            _moveComponent.Move(moveDirection);
        }
        else
        {
           // Debug.Log("Position Reached");
        }
    }

}
