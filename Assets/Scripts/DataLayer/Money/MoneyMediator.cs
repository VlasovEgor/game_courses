
using Zenject;

public class MoneyMediator : IGameDataLoader, IGameDataSaver
{
    private MoneyRepository _moneyRepository;
    private MoneyConverter _moneyConverter;

    [Inject]
    public void Construct(MoneyRepository repository)
    {
        _moneyRepository = repository;
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
