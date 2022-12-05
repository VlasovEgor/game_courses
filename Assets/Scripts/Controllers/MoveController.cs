using UnityEngine;

public class MoveController : MonoBehaviour,  IConstructListener, IStartGameListener, IFinishGameListener
{
    private IMovingComponent _movingComponent;
    private ManipulatorsInput _manipulatorsInput;

    public void Construct(GameContext context)
    {
        _manipulatorsInput = context.GetService<ManipulatorsInput>();
        _movingComponent = context.GetService<CharacterService>().GetCharacter().Get<IMovingComponent>();
    }

    public void OnStartGame()
    {
        _manipulatorsInput.OnMove += Move;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnMove += Move;
    }

    public void Move(Vector3 inputVector)
    {
        _movingComponent.Movement(inputVector);
    }
}
