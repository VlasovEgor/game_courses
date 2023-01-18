using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class SaveLoadUpgrade : MonoBehaviour
{
    public Action OnLoadUpgrade;

    [SerializeField] private PlayerInfo _playerInfo;

    private UpgradesMediator _upgadesMediator;
    private UpgradesRepository _upgradesRepository;

    public SaveLoadUpgrade()
    {
        _upgadesMediator = new UpgradesMediator();
        _upgradesRepository = new UpgradesRepository();
        _upgadesMediator.Construct(_upgradesRepository);
    }

    [Button]
    public void Save()
    {
        _upgadesMediator.SaveData(_playerInfo);
    }

    [Button]
    public void Load()
    {
        _upgadesMediator.LoadData(_playerInfo);
        OnLoadUpgrade?.Invoke();
    }
}
