using System;
using UnityEngine;

public class ManipulatorsInput : MonoBehaviour,IStartGameListener,IFinishGameListener
{
    public event Action<Vector3> OnMove;
    public event Action<Vector3> OnRotate;

    public event Action OnJump;
    public event Action OnShoot;
    public event Action OnMeleeAttack;

    private void Awake()
    {
        enabled = false;
    }

    void IStartGameListener.OnStartGame()
    {
        enabled = true;
    }

    void IFinishGameListener.OnFinishGame()
    {
        enabled = false;
    }

    private void Update()
    {
        HandleMoveKeyboard();
        HandleJumpKeyboard();
        ProcessingMouseClicks();
        Rotate();
    }

    private void ProcessingMouseClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(Input.GetMouseButtonDown(1))
        {
            MeleeAttack();
        }
    }
    private void Shoot()
    {
        OnShoot?.Invoke();
    }

    private void MeleeAttack()
    {
        OnMeleeAttack?.Invoke();
    }

    private void HandleMoveKeyboard()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Move(inputVector);
    }

    private void Move(Vector3 inputVector)
    {
        OnMove?.Invoke(inputVector);
    }

    private void Rotate()
    {
        Vector3 rotateVector = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        OnRotate?.Invoke(rotateVector);
    }

    private void HandleJumpKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        OnJump?.Invoke();
    }
}