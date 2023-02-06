using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EffectorComponent : MonoBehaviour, IEffectorComponent
{
    public event Action<IEffect> OnEffectAdded
    {
        add { _engine.OnEffectAdded += value; }
        remove { _engine.OnEffectAdded -= value; }
    }

    public event Action<IEffect> OnEffectRemoved
    {
        add { _engine.OnEffectRemoved += value; }
        remove { _engine.OnEffectRemoved -= value; }
    }

    [FormerlySerializedAs("receiver")]
    [SerializeField]
    private EffectEngine _engine;

    public void AddEffect(IEffect effect)
    {
        _engine.AddEffect(effect);
    }

    public void RemoveEffect(IEffect effect)
    {
        _engine.RemoveEffect(effect);
    }
}
