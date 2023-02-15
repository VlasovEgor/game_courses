using UnityEngine;
using Zenject;

public class ChestFactory : MonoInstaller
{
    [Inject] private MonoBehaviour _monoContext;

    [Inject] private IGameContext _gameContext;

    public Chest CreateChest(ChestConfig config, MonoBehaviour monoContext, IGameContext gameContext)
    {   
        var chest = config.InstatiateChest(monoContext, gameContext);
        return chest;
    }
}
