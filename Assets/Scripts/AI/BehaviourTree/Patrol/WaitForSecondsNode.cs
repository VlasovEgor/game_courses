using System.Collections;
using UnityEngine;

public sealed class WaitForSecondsNode : BehaviourNode
{
    [SerializeField]
    private float _seconds;

    [SerializeField]
    private bool _success;

    private Coroutine _coroutine;

    protected override void Run()
    {
        _coroutine = StartCoroutine(WaitForSeconds());
    }

    protected override void OnAbort()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(_seconds);
        _coroutine = null;
        Return(_success);
    }
}
