using System;
using UnityEngine;

[Serializable]
public class FigthWithEnemyCondition_CheckDistanceToEnemy : IFigthWithEnemyCondition
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _minDistance;

    public bool IsTrue(FightWihtEnemyOperation operation)
    {
        Vector3 targetPosition= operation.TargetEnemy.Get<GetPositionComponent>().GetPosition();
        Vector3 playerPosition = _playerTransform.position;
        float distance= Vector3.Distance(playerPosition, targetPosition);
        Debug.Log(distance);
        return distance <= _minDistance;
    }
}

