using UnityEngine;

public class AttackController : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
{
    private IShotComponent _shotComponent;
    private ManipulatorsInput _manipulatorsInput;

    public void Construct(GameContext context)
    {
        _manipulatorsInput = context.GetService<ManipulatorsInput>();
        _shotComponent = context.GetService<CharacterService>().GetCharacter().Get<IShotComponent>();
    }
    public void OnStartGame()
    {
        _manipulatorsInput.OnShoot += Shot;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnShoot += Shot;
    }

    private void Shot()
    {
        _shotComponent.Shoot();
    }
}
