using System;
using UnityEngine;

[Serializable]
public class FigthWithEnemyAction_RotateToEnemy : IFigthWithEnemyAction
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _rotationSercetivity;

    public void Do(FightWihtEnemyOperation operation)
    {   
        var targetPosition= operation.TargetEnemy.Get<GetPositionComponent>().GetPosition();
        _playerTransform.LookAt(targetPosition, Vector3.up); // � ��� ������� ������ ��� � ��� ���������
       // _playerTransform.rotation = Quaternion.Lerp(_playerTransform.rotation, Quaternion.LookRotation(targetPosition), Time.deltaTime * _rotationSercetivity);
    }
}
