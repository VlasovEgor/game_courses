using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : MonoBehaviour
{

    [ReadOnly] [ShowInInspector] private List<object> _listeners = new List<object>();

    private readonly List<object> _services = new();

    public T GetService<T>()
    {
        foreach (var service in _services)
        {
            if (service is T result)
            {
                return result;
            } 
        }

        throw new Exception($"Service of type {typeof(T).Name} is not found");
    }

    public void AddService(object sercvice)
    {
        _services.Add(sercvice);
    }

    public void RemoveService(object sercvice)
    {
        _services.Remove(sercvice);
    }

    public void AddListener(object listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(object listener)
    {
        _listeners.Remove(listener);
    }

    [Button]
    public void ConstructGame()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IConstructListener constractListener)
            {
                constractListener.Construct(context: this);
            }
        }

        Debug.Log("Game construct");
    }

    [Button]
    public void StartGame()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IStartGameListener startListener)
            {
                startListener.OnStartGame();
            }
        }

        Debug.Log("Game started");

    }

    [Button]
    public void FinishGame()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IFinishGameListener finishListener)
            {
                finishListener.OnFinishGame();
            }
        }

        Debug.Log("Game finished");
    }
}