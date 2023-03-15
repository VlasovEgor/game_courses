using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public sealed class Blackboard : MonoBehaviour
{
    public event Action<string, object> OnVariableAdded;

    public event Action<string, object> OnVariableRemoved;

    public event Action<string, object> OnVariableChanged;

    [ShowInInspector, ReadOnly]
    private readonly Dictionary<string, object> _variables = new();

    public T GetVariable<T>(string key)
    {
        return (T)_variables[key];
    }

    public bool TryGetVariable<T>(string key, out T value)
    {
        if (_variables.TryGetValue(key, out var result))
        {
            value = (T)result;
            return true;
        }

        value = default;
        return false;
    }

    public bool HasVariable(string key)
    {
        return _variables.ContainsKey(key);
    }



    [Title("Methods")]
    [Button]
    public void AddVariable(string key, object value)
    {
        if (_variables.ContainsKey(key))
        {
            throw new Exception($"Variable {key} is already added!");
        }

        _variables.Add(key, value);
        OnVariableAdded?.Invoke(key, value);
    }

    [Button]
    public void RemoveVariable(string key)
    {
        if (!_variables.TryGetValue(key, out var value))
        {
            return;
        }

        _variables.Remove(key);
        OnVariableRemoved?.Invoke(key, value);
    }

    public void ChangeVariable(string key, object value)
    {
        if (!_variables.ContainsKey(key))
        {
            throw new Exception($"Variable {key} is not found!");
        }

        _variables[key] = value;
        OnVariableChanged?.Invoke(key, value);
    }
}
