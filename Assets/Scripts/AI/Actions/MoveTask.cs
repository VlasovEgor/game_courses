using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class MoveTask : Task
{
    private IEntity _unit;

    private Vector3 _targetPosition;

    private Coroutine _moveCoroutine;

    private float _stoppingDistance;

    [Button]
    public void SetTargetPosition(Transform transformPosition)
    {
        _targetPosition = transformPosition.position;
    }

    [Button]
    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
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
    }

    [Button]
    protected override void Do()
    {
        _moveCoroutine = StartCoroutine(MoveRoutine());
    }

    protected override void OnCancel()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    private IEnumerator MoveRoutine()
    {
        var positionComponent = _unit.Get<GetPositionComponent>();
        var moveComponent = _unit.Get<MoveInDirectionComponent>();
        var period = new WaitForFixedUpdate();

        while (true)
        {
            var distanceVector = _targetPosition - positionComponent.GetPosition();
            var distance = distanceVector.magnitude;

            if (distance <= _stoppingDistance)
            {
                break;
            }

            var direction = distanceVector.normalized;
            moveComponent.Move(direction);

            yield return period;
        }

        yield return period;

        Return(true);
        _moveCoroutine = null;
    }

}
