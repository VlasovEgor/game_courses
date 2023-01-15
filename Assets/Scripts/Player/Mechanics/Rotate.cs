using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private IntBehaviour _rotationSercetivity;
    [SerializeField] private Transform _transformRotate;
    [SerializeField] private MoveInDirectionEngine _moveEngine;

    private void Update()
    {
        if (_moveEngine.IsMoving)
        {
            OnRotating(_moveEngine.Direction);
        }
    }

    void OnRotating(Vector3 direction)
    {
        var dirextionXZ = new Vector3(direction.x, 0, direction.z);
        _transformRotate.rotation = Quaternion.Lerp(_transformRotate.rotation, Quaternion.LookRotation(dirextionXZ), Time.deltaTime * _rotationSercetivity.Value);
    }
}
