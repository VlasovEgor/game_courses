using UnityEngine;
using UnityEngine.UIElements;

public class MoveInDirectionMechanics : MonoBehaviour
{
    [SerializeField] private MoveInDirectionEngine _moveEngine;
    [SerializeField] private IntBehaviour _speed;
    [SerializeField] private Transform _transform;

    private void Update()
    {
        if(_moveEngine.IsMoving) 
        {
            MoveTransform(_moveEngine.Direction);
        }
    }

    private void MoveTransform(Vector3 direction)
    {
        var velocity= direction *(_speed.Value*Time.deltaTime);
        _transform.position += velocity;

        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
