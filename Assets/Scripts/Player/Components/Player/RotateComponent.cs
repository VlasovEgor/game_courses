using UnityEngine;

public class RotateComponent : MonoBehaviour,IRotateComponent
{
    [SerializeField] private VectorEventReceiver _rotateReceiver;

    public void Rotate(Vector3 vector)
    { 
        _rotateReceiver.Offset(vector);
    }
}
