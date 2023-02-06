using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler_Health : EffectHandler
{
    [SerializeField] private Elementary.IntBehaviour _healthSummand;

    public override void OnEffectAdded(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectParameterKey.HEALTH, out var summand))
        {
            _healthSummand.Plus(summand);
        }
    }

    public override void OnEffectRemoved(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectParameterKey.HEALTH, out var summand))
        {
            _healthSummand.Minus(summand);
        }
    }
}
