
using Sirenix.OdinInspector;
using UnityEngine;

public class SaveLoadMoney : MonoBehaviour
{
    [SerializeField] private GameContext _gameContext;

    private MoneyMediator _moneyMediator;
    private MoneyRepository _moneyRepository;

    public SaveLoadMoney()
    {
        _moneyMediator = new MoneyMediator();
        _moneyRepository = new MoneyRepository();
        _moneyMediator.Construct(_moneyRepository);

    }

    [Button]
    public void Save()
    {
        _moneyMediator.SaveData(_gameContext);
    }

    [Button]
    public void Load()
    {
        _moneyMediator.LoadData(_gameContext);
    }
}
