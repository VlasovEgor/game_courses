using System;
using Zenject;

public class ChestsMediator: IInitializable, IDisposable
{
   [Inject] private ChestsRepository _chestsRepository;
   [Inject] private ChestManager _manager;

    void IInitializable.Initialize()
    {
        LoadData();
    }

    void IDisposable.Dispose()
    {
        SaveData();
    }

    public void LoadData()
    {
        _chestsRepository.LoadChests(out ChestsData data);
        _manager.Setup(data.ChestsList);
    }

    public void SaveData()
    {
        var data = new ChestsData
        {
            ChestsList = _manager.GetAllChests()
        };

        _chestsRepository.SaveChests(data);
    }
}
