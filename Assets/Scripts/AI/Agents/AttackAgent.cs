using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class AttackAgent : Agent
{
    [SerializeField] private MoveAgent _moveAgent;

    [SerializeField] private MeleeCombatAgent _meleeCombatAgent;

    [ShowInInspector, ReadOnly] private IEntity _unit;

    [ShowInInspector, ReadOnly] private IEntity _target;

    [ShowInInspector, ReadOnly] private float _stoppingDistance;

    private Coroutine _attackCoroutine;

    private IGetPositionComponent _unitComponent;

    private IGetPositionComponent _targetComponent;

    [Button]
    public void SetUnit(IEntity unit)
    {
        _moveAgent.SetUnit(unit);
        _meleeCombatAgent.SetUnit(unit);
        _unit = unit;
        _unitComponent = unit?.Get<IGetPositionComponent>();
    }

    [Button]
    public void SetTarget(IEntity target)
    {
        _meleeCombatAgent.SetTarget(target);
        _target = target;
        _targetComponent = target?.Get<IGetPositionComponent>();
    }

    [Button]
    public void SetStoppingDistance(float stoppingDistance)
    {
        _moveAgent.SetStoppingDistance(stoppingDistance);
        _stoppingDistance = stoppingDistance;
    }

    protected override void OnStart()
    {
        _attackCoroutine = StartCoroutine(AttackRoutine());
    }

    protected override void OnStop()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }

        _moveAgent.Stop();
        _meleeCombatAgent.Stop();
    }

    private IEnumerator AttackRoutine()
    {
        var period = new WaitForFixedUpdate();


        while (true)
        {
            if (_targetComponent != null && _unitComponent != null)
            {
                _moveAgent.SetTargetPosiiton(_targetComponent.GetPosition());
                UpdateBehaviour(_unitComponent.GetPosition(), _targetComponent.GetPosition());
            }
            else
            {
                _moveAgent.Stop();
                _meleeCombatAgent.Stop();
            }

            yield return period;
        }
    }

    private void UpdateBehaviour(Vector3 unitPosiiton, Vector3 targetPosition)
    {
        var distance = unitPosiiton - targetPosition;
        var distanceReached = distance.sqrMagnitude <= _stoppingDistance * _stoppingDistance;

        if (distanceReached)
        {
            if (_moveAgent.IsPlaying)
            {
                _moveAgent.Stop();
            }

            if (!_meleeCombatAgent.IsPlaying)
            {
                _meleeCombatAgent.Play();
            }
        }
        else
        {
            if (!_moveAgent.IsPlaying)
            {
                _moveAgent.Play();
            }

            if (_meleeCombatAgent.IsPlaying)
            {
                _meleeCombatAgent.Stop();
            }
        }
    }

}
