using Sirenix.OdinInspector;
using UnityEngine;

public class UpgradesSystemInstaller : MonoBehaviour, IConstructListener
{
    [SerializeField] private GameContext _gameContext;
    [SerializeField] private ConveyorUpgradeCatalog[] _catalogs;

    [ShowInInspector] private readonly UpgradesManager _upgradesManager = new();

    public void Construct(GameContext context)
    {
        var moneyStorage = context.GetService<MoneyStorage>();
        _upgradesManager.Construct(moneyStorage, _catalogs);
        _upgradesManager.Setup();
        context.AddService(_upgradesManager);
    }
}