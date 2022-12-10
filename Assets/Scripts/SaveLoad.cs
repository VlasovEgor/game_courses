
using Sirenix.OdinInspector;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private GameContext _gameContext;
    [SerializeField] private int _id;

    private CharacterMediator _characterMediator;
    private CharacterRepository _characterRepository;

    public SaveLoad()
    {
        _characterMediator = new CharacterMediator();
        _characterRepository = new CharacterRepository();
        _characterMediator.Construct(_characterRepository);

    }

    [Button]
    public void Save()
    {
        _characterMediator.SaveData(_gameContext, _id);
    }

    [Button]
    public void Load() 
    {
        _characterMediator.LoadData(_gameContext, _id);
    }

}