using Sirenix.OdinInspector;
using UnityEngine;

public class UpgradesSystemInstaller : MonoBehaviour, IConstructListener
{
    [SerializeField] private GameContext _gameContext;
    [SerializeField] private FactoryUpgradeCatalog[] _catalogs;

    [ShowInInspector] private readonly UpgradesManager _upgradesManager = new();

    private Upgrade[][] _upgrades;

    private void Awake()
    {
        CreateUpgrades();
    }

    public void Construct(GameContext context)
    {
        var moneyStorage = context.GetService<MoneyStorage>();
        _upgradesManager.Construct(moneyStorage, _catalogs);
        _upgradesManager.Setup(_upgrades);
        context.AddService(_upgradesManager);
    }

    private void CreateUpgrades()
    {
        _upgrades = new Upgrade[_catalogs.Length][];

        for (int i = 0; i < _upgrades.Length; i++)
        {
            _upgrades[i] = _catalogs[i].GetAllUpgrades();

            for (int j = 0; j < _upgrades[i].Length; j++)
            {
                _gameContext.AddListener(_upgrades[i][j]);
            }
        }
    }
}