using System.Collections;
using UnityEngine;

public class RotateInDirectionState : Elementary.StateCoroutine
{
    [SerializeField] private MoveInDirectionEngine _moveEngine;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _rotationSpeed = 1;

    protected override IEnumerator Do()
    {
        while (true)
        {
            var delay = new WaitForFixedUpdate();
            while (true)
            {
                yield return delay;
                RotateTransform();
            }
        }
    }

    private void RotateTransform()
    {
        var direction = _moveEngine.Direction;
        var dirextionXZ = new Vector3(direction.x, 0, direction.z);
        _transform.rotation= Quaternion.Lerp(_transform.rotation,Quaternion.LookRotation(dirextionXZ ), Time.deltaTime* _rotationSpeed);
    }
}
