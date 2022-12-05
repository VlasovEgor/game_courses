using UnityEngine;

public class JumpController : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
{
    private IJumpComponent _jumpComponent;
    private ManipulatorsInput _manipulatorsInput;

    public void Construct(GameContext context)
    {
        _manipulatorsInput = context.GetService<ManipulatorsInput>();
        _jumpComponent = context.GetService<CharacterService>().GetCharacter().Get<IJumpComponent>();
    }

    public void OnStartGame()
    {
        _manipulatorsInput.OnJump += Jump;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnJump -= Jump;
    }

    private void Jump()
    {
        _jumpComponent.Jump();
    }
}
