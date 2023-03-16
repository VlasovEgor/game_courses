using Elementary;
using UnityEngine;
using Game.GameEngine.GameResources;

public abstract class MonoCondition : MonoBehaviour, ICondition
{
    public abstract bool IsTrue();
}


public sealed class ConditionBehaviour_IsLimitReached : MonoCondition
{
    [SerializeField]
    private UResourceSourceLimited source;

    public override bool IsTrue()
    {
        return !this.source.IsLimit;
    }
}
