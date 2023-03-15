using UnityEngine;


public sealed class CheckBlackboardVariableNode : BehaviourNode
{
    [SerializeField]
    private Blackboard _blackboard;

    [SerializeField, BlackboardKey]
    private string _variableName;

    protected override void Run()
    {
        var variableExists = _blackboard.HasVariable(_variableName);
        Return(variableExists);
    }
}
