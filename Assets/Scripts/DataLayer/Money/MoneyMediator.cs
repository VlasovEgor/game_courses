using Services;

public class MoneyMediator : IGameDataLoader, IGameDataSaver
{
    private MoneyRepository _moneyRepository;
    private MoneyConverter _moneyConverter;

    [ServiceInject]
    public void Construct(MoneyRepository repository,MoneyConverter moneyConverter)
    {
        _moneyRepository = repository;
        _moneyConverter = moneyConverter;
    }

    public void LoadData(IGameContext context)
    {
        _moneyRepository.TryLoadMoney(out MoneyData data);

        MoneyStorage moneyStorage = context.GetService<MoneyStorage>();

        _moneyConverter.SetupMoney(moneyStorage, data);
    }

    public void SaveData(IGameContext context)
    {
        MoneyStorage moneyStorage = context.GetService<MoneyStorage>();
        var data = _moneyConverter.ConvertToData(moneyStorage);

        _moneyRepository.SaveMoney(data);
    }
}
