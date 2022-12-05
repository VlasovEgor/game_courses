using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
{
    private Transform _targetCamera;
    private IGetPositionComponent _PositionComponent;

    private void Awake()
    {
        enabled = false;
    }

    private void LateUpdate()
    {
        _targetCamera.position = _PositionComponent.GetPosition();
    }

    public void Construct(GameContext context)
    {
        _targetCamera = context.GetService<CameraService>().CameraTransfrom;
        _PositionComponent = context.GetService<CharacterService>().GetCharacter().Get<IGetPositionComponent>();
    }

    public void OnStartGame()
    {
        enabled = true;
    }

    public void OnFinishGame()
    {
        enabled = false;
    }
}
