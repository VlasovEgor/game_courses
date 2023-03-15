using UnityEngine;

public sealed class MeleeCombatNode : BehaviourNode
{
    [SerializeField]
    private Blackboard _blackboard;

    [BlackboardKey]
    [SerializeField]
    private string _unitKey;

    [BlackboardKey]
    [SerializeField]
    private string _targetKey;

    [SerializeField]
    private bool _success = true;

    private IFightWithEnemyComponent _unitComponent;

    protected override void Run()
    {
        if (!_blackboard.TryGetVariable(_unitKey, out IEntity unit))
        {
            Return(false);
            return;
        }

        if (!_blackboard.TryGetVariable(_targetKey, out IEntity target))
        {
            Return(false);
            return;
        }

        _unitComponent = unit.Get<IFightWithEnemyComponent>();
        StartCombat(target);
    }

    private void StartCombat(IEntity target)
    {
        if (_unitComponent.IsFighting)
        {
            _unitComponent.StopFight();
        }

        _unitComponent.OnFinished += OnCombatFinished;

        var operation = new FightWihtEnemyOperation(target);

        if (_unitComponent.CanFight(operation))
        {
            _unitComponent.StartFight(operation);
        }
        else
        {
            Return(_success);
        }
    }

    private void OnCombatFinished(FightWihtEnemyOperation obj)
    {
        _unitComponent.OnFinished -= OnCombatFinished;
        Debug.Log($"COMBAT FINISHED {_success}");
        Return(_success);
    }

    protected override void OnAbort()
    {
        _unitComponent.OnFinished -= OnCombatFinished;
        if (_unitComponent.IsFighting)
        {
            _unitComponent.StopFight();
        }
    }
}