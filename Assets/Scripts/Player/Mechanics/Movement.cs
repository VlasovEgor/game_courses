using Elementary;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private VectorEventReceiver _movingReceiver;
    [SerializeField] private IntBehaviour _speed;
    [SerializeField] private FloatBehaviour _speedMultiplier;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _movingReceiver.OnEvent += OnMoving;
    }

    private void OnDisable()
    {
        _movingReceiver.OnEvent -= OnMoving;
    }

    private void OnMoving(Vector3 inputVector)
    {
        var currentSpeed = _speed.Value * _speedMultiplier.Value;
        _rigidbody.velocity = new Vector3(inputVector.x * currentSpeed, _rigidbody.velocity.y, inputVector.z * currentSpeed);
    }
}
