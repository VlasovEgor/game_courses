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
            var player = _playersGroup.Players[i];
            if (_characterRepository.TryLoadStats(out CharacterData data, player.PlayerID))
            {
                var character = _playersGroup.Players[i];
                _characterConverter.SetupStats(character, data);
            }
        }
    }

    void IGameDataSaver.SaveData(IGameContext context)
    {
        _playersGroup = context.GetService<PlayersGroup>();

        for (int i = 0; i < _playersGroup.Players.Length; i++)
        {
            var character = _playersGroup.Players[i];
            var data = _characterConverter.ConvertToData(character);

            _characterRepository.SaveStats(data, i);
        }
    }
}