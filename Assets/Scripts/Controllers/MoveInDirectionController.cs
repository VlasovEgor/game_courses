using UnityEngine;

public class MoveInDirectionController : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
{
    private IMoveInDirectionComponent _movingComponent;
    private ManipulatorsInput _manipulatorsInput;

    void IConstructListener.Construct(GameContext context)
    {
        _manipulatorsInput = context.GetService<ManipulatorsInput>();
        _movingComponent = context.GetService<CharacterService>().GetCharacter().Get<IMoveInDirectionComponent>();
    }

    void IStartGameListener.OnStartGame()
    {
        _manipulatorsInput.OnMove += OnDirectionMoved;
    }

    void IFinishGameListener.OnFinishGame()
    {
        _manipulatorsInput.OnMove -= OnDirectionMoved;
    }

    private void OnDirectionMoved(Vector3 screenDirection)
    {
        var worldDirection = new Vector3(screenDirection.x, 0.0f, screenDirection.z);
        _movingComponent.Move(worldDirection);
    }
}
