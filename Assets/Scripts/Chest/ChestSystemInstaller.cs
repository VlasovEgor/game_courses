using Sirenix.OdinInspector;
using UnityEngine;

public class ChestSystemInstaller : MonoBehaviour,IInitGameListener
{
    [SerializeField] private ChestManager _manager;
    [SerializeField] private ChestCatalog _chestCatalog;

    public void OnInitGame()
    {
        _manager.CreateChests(_chestCatalog);
    }

    [Button]
    public void OpenChest(string chestId)
    {
        _manager.OpenChest(chestId);
    }

}