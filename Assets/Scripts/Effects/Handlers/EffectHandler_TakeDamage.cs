using Elementary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler_TakeDamage : EffectHandler
{
    [SerializeField] private FloatBehaviour _takeDamageMultiplier;

    public override void OnEffectAdded(IEffect effect)
    {
        if (effect.TryGetParameter<float>(EffectParameterKey.TAKE_DAMAGE, out var multiplier))
        {
            _takeDamageMultiplier.Multiply(multiplier);
        }
    }

    public override void OnEffectRemoved(IEffect effect)
    {
        if (effect.TryGetParameter<float>(EffectParameterKey.TAKE_DAMAGE, out var multiplier))
        {
            _takeDamageMultiplier.Divide(multiplier);
        }
    }
}
