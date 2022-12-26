using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private VectorEventReceiver _rotateReceiver;
    [SerializeField] private IntBehaviour _rotationSercetivity;
    [SerializeField] private Transform _transformRotate;

    private void OnEnable()
    {
        _rotateReceiver.OnEvent += OnRotating;
    }

    private void OnDisable()
    {
        _rotateReceiver.OnEvent -= OnRotating;
    }

    void OnRotating(Vector3 rotateVector)
    {
        Debug.Log("MAY DAY" + rotateVector);
        _transformRotate.Rotate(rotateVector*_rotationSercetivity.Value);
    }
}
