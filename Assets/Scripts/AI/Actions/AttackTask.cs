using Sirenix.OdinInspector;
using UnityEngine;

public class AttackTask : Task, ITaskCallback
{
    [SerializeField] private MoveTask _moveTask;

    [SerializeField] private MeleeCombatTask _combatTask;

    [Button]
    public void SetUnit(IEntity unit)
    {
        _moveTask.SetUnit(unit);
        _combatTask.SetUnit(unit);
    }

    [Button]
    public void SetTarget(IEntity target)
    {
        _moveTask.SetTargetPosition(target.Get<GetPositionComponent>().GetPosition());
        _combatTask.SetTarget(target);

    }

    [Button]
    public void SetStoppingDistance(float stoppingDistance)
    {
        _moveTask.SetStoppingDistance(stoppingDistance);
    }

    protected override void Do()
    {
        _moveTask.Do(callback: this);
    }

    protected override void OnCancel()
    {
        _moveTask.Cansel();
        _combatTask.Cansel();
    }

    void ITaskCallback.OnComplete(Task task, bool success)
    {
        if (task == _moveTask)
        {
            _combatTask.Do(callback: this);
        }

        if (task == _combatTask)
        {
            Return(true);
        }
    }
}
