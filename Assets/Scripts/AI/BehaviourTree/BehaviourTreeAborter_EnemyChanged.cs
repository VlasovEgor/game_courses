using UnityEngine;


public sealed class BehaviourTreeAborter_EnemyChanged : MonoBehaviour
{
    [SerializeField]
    private BehaviourTree _behaviourTree;

    [Space, SerializeField]
    private Blackboard _blackboard;

    [SerializeField, BlackboardKey]
    private string _enemyKey;

    private void OnEnable()
    {
        _blackboard.OnVariableAdded += OnVariableChanged;
        _blackboard.OnVariableRemoved +=     OnVariableChanged;
        _blackboard.OnVariableChanged += OnVariableChanged;
    }

    private void OnDisable()
    {
        _blackboard.OnVariableAdded -= OnVariableChanged;
        _blackboard.OnVariableRemoved -= OnVariableChanged;
        _blackboard.OnVariableChanged -= OnVariableChanged;
    }

    private void OnVariableChanged(string key, object _)
    {
        if (key == _enemyKey)
        {
            _behaviourTree.Abort();
        }
    }
}
