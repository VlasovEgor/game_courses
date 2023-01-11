using System.Collections;
using UnityEngine;

public abstract class StateCoroutine : State
{
    private Coroutine _coroutine;

    public override void Enter()
    {
        if (_coroutine==null)
        {
            _coroutine = StartCoroutine(Do());
        }
    }

    public override void Exit() 
    {
        if (_coroutine != null)
        {
            StopCoroutine(Do());
            _coroutine = null;
        }
    }

    protected abstract IEnumerator Do();

}
