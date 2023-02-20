using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class PatrolAgent : Agent
{
    [SerializeField] private MoveAgent _moveAgent;

    [ShowInInspector, ReadOnly] private IEntity _unit;

    [ShowInInspector, ReadOnly] private float _stoppingDistance = 0.2f;

    [ShowInInspector, ReadOnly] private float _stoppingTime = 0.2f;

    [SerializeField] private Transform[] _targetsArray;

    private IGetPositionComponent _unitComponent;

    private Coroutine _patrolCoroutine;

    private int _counter = 0;

    private int _indexArray = 0;


    [Button]
    public void SetUnit(IEntity unit)
    {
        _moveAgent.SetUnit(unit);
        _unit = unit;
        _unitComponent = unit?.Get<IGetPositionComponent>();

    }

    [Button]
    public void SetTargets(Transform[] targets)
    {
        _targetsArray = targets;
    }

    [Button]
    public void SetStoppingDistance(float stoppingDistance)
    {
        _moveAgent.SetStoppingDistance(stoppingDistance);
        _stoppingDistance = stoppingDistance;
    }

    [Button]
    public void SetStoppingTime(float time)
    {
        _stoppingTime=time;
    }

    protected override void OnStart()
    {
        _patrolCoroutine = StartCoroutine(PatrolRoutine());
    }

    protected override void OnStop()
    {
        if (_patrolCoroutine != null)
        {
            StopCoroutine(_patrolCoroutine);
            _patrolCoroutine = null;
        }

        _moveAgent.Stop();
    }

    private IEnumerator PatrolRoutine()
    {
        var period = new WaitForFixedUpdate();
        _moveAgent.Play();

        while (true)
        {
            if (_targetsArray != null && _unitComponent != null)
            {
                _moveAgent.SetTargetPosiiton(_targetsArray[_indexArray]);
                UpdateBehaviour(_unitComponent.GetPosition(), _targetsArray[_indexArray].position);
            }
            else
            {
                _moveAgent.Stop();
            }

            yield return period;
        }
    }

    private void UpdateBehaviour(Vector3 unitPosiiton, Vector3 targetPosition)
    {
        var distance = unitPosiiton - targetPosition;
        var distanceReached = distance.sqrMagnitude < _stoppingDistance * _stoppingDistance;

        if (distanceReached == true && _moveAgent.IsPlaying == true)
        {
            _moveAgent.Stop();
            StartCoroutine(StoppingRoutine());
        }
       // else
       // {
       //     if (_moveAgent.IsPlaying == false)
       //     {
       //         _moveAgent.Play();
       //     } 
       // }

    }

    private IEnumerator StoppingRoutine()
    {
        yield return new WaitForSeconds(_stoppingTime);
        StopIsOver();
        
    }

    private void StopIsOver()
    {
        SetNewTargetPointIndex();
        _moveAgent.Play();
    }

    private void SetNewTargetPointIndex()
    {
        _counter++;
        
        _indexArray = _counter / _targetsArray.Length;

        if (_indexArray == _targetsArray.Length)
        {
            _indexArray = 0;
            _counter = 0;
        }
    }
}