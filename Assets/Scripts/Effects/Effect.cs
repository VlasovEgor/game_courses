using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Effect : IEffect
{
    [SerializeReference]
    private List<IEffectParameter> parameters;

    public Effect()
    {
        parameters = new List<IEffectParameter>();
    }

    public Effect(params IEffectParameter[] parameters)
    {
        this.parameters = new List<IEffectParameter>(parameters);
    }

    public T GetParameter<T>(EffectParameterKey name)
    {
        for (int i = 0, count = parameters.Count; i < count; i++)
        {
            var parameter = parameters[i];
            if (parameter.Name == name && parameter is IEffectParameter<T> tParameter)
            {
                return tParameter.Value;
            }
        }

        throw new Exception($"Parameter {name} is not found!");
    }

    public bool TryGetParameter<T>(EffectParameterKey name, out T value)
    {
        for (int i = 0, count = parameters.Count; i < count; i++)
        {
            var parameter = parameters[i];
            if (parameter.Name == name && parameter is IEffectParameter<T> tParameter)
            {
                value = tParameter.Value;
                return true;
            }
        }

        value = default;
        return false;
    }
}
