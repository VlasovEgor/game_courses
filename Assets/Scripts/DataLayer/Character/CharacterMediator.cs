
using Zenject;

public class CharacterMediator: IGameDataLoader,IGameDataSaver
{
    private CharacterRepository _characterRepository;
    private CharacterConverter _characterConverter;
    private PlayersGroup _playersGroup;

    [Inject]
    public void Construct(CharacterRepository repository)
    {
        _characterRepository= repository;
    }

    public void LoadData(IGameContext context)
    {   
        _playersGroup = context.GetService<PlayersGroup>();

        for (int i = 0; i < _playersGroup.Players.Length; i++)
        {   
            int id = _playersGroup.CheckId(i);
            _characterRepository.TryLoadStats(out CharacterData data, id);
            IEntity character = _playersGroup.FindPlayer(id).GetEntity();
            _characterConverter.SetupStats(character, data);
        }
    }

    public void SaveData(IGameContext context)
    {
        _playersGroup = context.GetService<PlayersGroup>();

        for (int i = 0; i < _playersGroup.Players.Length; i++)
        {   
            int id= _playersGroup.CheckId(i);
            IEntity character = _playersGroup.FindPlayer(id).GetEntity();
            var data = _characterConverter.ConvertToData(character);

            _characterRepository.SaveStats(data, i);
        }
    }
} 