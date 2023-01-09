using Services;

public class CharacterMediator : IGameDataLoader, IGameDataSaver
{
    private CharacterRepository _characterRepository;
    private CharacterConverter _characterConverter;
    private PlayersGroup _playersGroup;

    [ServiceInject]
    public void Construct(CharacterRepository repository,CharacterConverter characterConverter)
    {
        _characterRepository = repository;
        _characterConverter = characterConverter;
    }


    void IGameDataLoader.LoadData(IGameContext context)
    {
        _playersGroup = context.GetService<PlayersGroup>();

        for (int i = 0; i < _playersGroup.Players.Length; i++)
        {
            ServiceInjector.ResolveDependencies();
            int id = _playersGroup.CheckId(i);
            if (_characterRepository.TryLoadStats(out CharacterData data, id))
            {
                IEntity character = _playersGroup.FindPlayer(id).GetEntity();
                _characterConverter.SetupStats(character, data);
            }

        }
    }

    void IGameDataSaver.SaveData(IGameContext context)
    {
        _playersGroup = context.GetService<PlayersGroup>();

        for (int i = 0; i < _playersGroup.Players.Length; i++)
        {
            int id = _playersGroup.CheckId(i);
            IEntity character = _playersGroup.FindPlayer(id).GetEntity();
            var data = _characterConverter.ConvertToData(character);

            _characterRepository.SaveStats(data, i);
        }
    }
}