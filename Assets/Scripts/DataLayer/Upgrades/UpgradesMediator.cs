using Services;

public class UpgradesMediator : IGameDataLoader, IGameDataSaver
{
    private UpgradesRepository _upgradesRepository;
    private UpgradesConverter _upgradesConverter;

    [ServiceInject]
    public void Construct(UpgradesRepository repository,UpgradesConverter upgradesConverter)
    {
        _upgradesRepository = repository;
        _upgradesConverter = upgradesConverter;
    }

    public void LoadData(IGameContext context)
    {
        var playerUpgrade = context.GetService<UpgradesManager>().PlayerUpgrade;
       _upgradesRepository.TryLoadStats(out UpgradesPlayerData data);
       _upgradesConverter.SetupStats(playerUpgrade, data);
    }

    public void SaveData(IGameContext context)
    {
        var playerUpgrade = context.GetService<UpgradesManager>().PlayerUpgrade;
        var data = _upgradesConverter.ConvertToData(playerUpgrade);
        _upgradesRepository.SaveStats(data);
    }
}
