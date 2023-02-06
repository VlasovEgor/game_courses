using System;
using UnityEngine;

[Serializable]
public class AbstractEffectParameter<T> : IEffectParameter<T>
{
    public EffectParameterKey Name
    {
        get { return _name; }
    }

    public T Value
    {
        get { return _value; }
    }

    [SerializeField]
    private EffectParameterKey _name;

    [SerializeField]
    private T _value;

    public AbstractEffectParameter()
    {
    }

    public AbstractEffectParameter(EffectParameterKey name, T value)
    {
        _name = name;
        _value = value;
    }
}

[Serializable]
public sealed class IntEffectParameter : AbstractEffectParameter<int>
{
    public IntEffectParameter()
    {
    }

    public IntEffectParameter(EffectParameterKey name, int value) : base(name, value)
    {
    }
}

[Serializable]
public sealed class FloatEffectParameter : AbstractEffectParameter<float>
{
    public FloatEffectParameter()
    {
    }

    public FloatEffectParameter(EffectParameterKey name, float value) : base(name, value)
    {
    }
}

[Serializable]
public sealed class StringEffectParameter : AbstractEffectParameter<string>
{
    public StringEffectParameter()
    {
    }

    public StringEffectParameter(EffectParameterKey name, string value) : base(name, value)
    {
    }
}