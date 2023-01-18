
using System;
using UnityEngine;

public class DeathComponent : MonoBehaviour,IDeathComponent
{
    [SerializeField] private EventReceiver _deathReceiver;

    public void Death()
    {
        _deathReceiver.Call();
    }

    public event Action OnDeathReceived
    {
        add { _deathReceiver.OnEvent += value; }
        remove { _deathReceiver.OnEvent -= value; }
    }
}
