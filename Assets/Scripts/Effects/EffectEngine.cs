using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EffectEngine : MonoBehaviour
{
    public event Action<IEffect> OnEffectAdded;

    public event Action<IEffect> OnEffectRemoved;

    [ReadOnly]
    [ShowInInspector]
    private readonly List<IEffect> _effects = new();

    [Space]
    [SerializeField]
    [FormerlySerializedAs("observers")]
    private List<EffectHandler> _handlers = new();

    public void AddEffect(IEffect effect)
    {
        for (var i = 0; i < _handlers.Count; i++)
        {
            var handler = _handlers[i];
            handler.OnEffectAdded(effect);
        }

        _effects.Add(effect);
        OnEffectAdded?.Invoke(effect);
    }

    public void RemoveEffect(IEffect effect)
    {
        if (!_effects.Remove(effect))
        {
            return;
        }

        for (var i = 0; i < _handlers.Count; i++)
        {
            var handler = _handlers[i];
            handler.OnEffectRemoved(effect);
        }

        OnEffectRemoved?.Invoke(effect);
    }

    public bool IsEffectExists(IEffect effect)
    {
        return _effects.Contains(effect);
    }

    public IEffect[] GetEffects()
    {
        return _effects.ToArray();
    }

    public void AddHandler(EffectHandler handler)
    {
        _handlers.Add(handler);
    }

    public void RemoveHandler(EffectHandler handler)
    {
        _handlers.Remove(handler);
    }
}
