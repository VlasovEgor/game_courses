using Elementary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler_Damage : EffectHandler
{
    [SerializeField] private Elementary.IntBehaviour _damageSummand;

    public override void OnEffectAdded(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectParameterKey.TAKE_DAMAGE, out var summand))
        {
            _damageSummand.Plus(summand);
        }
    }

    public override void OnEffectRemoved(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectParameterKey.TAKE_DAMAGE, out var summand))
        {
            _damageSummand.Minus(summand);
        }
    }
}
