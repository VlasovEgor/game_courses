using System.Collections;
using UnityEngine;

public class MoveInDirectionState :Elementary.StateCoroutine
{
    [SerializeField] private MoveInDirectionEngine _moveEngine;
    [SerializeField] private IntBehaviour _speed;
    [SerializeField] private Transform _transform;

    private void Awake()
    {
        enabled = false;
    }

    protected override IEnumerator Do()
    {
        var delay = new WaitForFixedUpdate();
        while (true)
        {
            yield return delay;
            MoveTransform();
        }
    }

    private void MoveTransform()
    {
        var direction = _moveEngine.Direction;
        var velocity = direction * (_speed.Value * Time.deltaTime);
        _transform.position += velocity;
    }
}