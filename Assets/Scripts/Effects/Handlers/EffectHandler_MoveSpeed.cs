using Elementary;
using UnityEngine;

public class EffectHandler_MoveSpeed : EffectHandler
{
    [SerializeField] private FloatBehaviour _speedMultiplier;

    public override void OnEffectAdded(IEffect effect)
    {
        if (effect.TryGetParameter<float>(EffectParameterKey.MOVE_SPEED, out var multiplier))
        {
            _speedMultiplier.Multiply(multiplier);
        }
    }

    public override void OnEffectRemoved(IEffect effect)
    {
        if (effect.TryGetParameter<float>(EffectParameterKey.MOVE_SPEED, out var multiplier))
        {
            _speedMultiplier.Divide(multiplier);
        }
    }
}