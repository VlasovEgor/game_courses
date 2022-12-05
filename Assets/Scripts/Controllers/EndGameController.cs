using UnityEngine;

public class EndGameController : MonoBehaviour, IConstructListener,IStartGameListener,IFinishGameListener
{
    private GameContext _context;
    private ITriggerComponent _playerComponent;

    public void Construct(GameContext context)
    {
        _context = context;
        _playerComponent = _context.GetService<CharacterService>().GetCharacter().Get<ITriggerComponent>();
    }

    public void OnStartGame()
    {
        _playerComponent.OnTriggerEntered += OnTriggerEntered;
    }

    public void OnFinishGame()
    {
        _playerComponent.OnTriggerEntered -= OnTriggerEntered;
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Finish"))
        {
            _context.FinishGame();
        }
    }
}