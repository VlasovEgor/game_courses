using UnityEngine;
using Zenject;

public class ChestsRepository
{
    [Inject] private ChestsData _chestsData;

    public void LoadChests(out ChestsData chestsData)
    {   
        chestsData = _chestsData;
        Debug.Log(_chestsData.ChestsList.Count);
        Debug.Log($"<color=orange> LOAD CHESTS DATA </color>");
    }

    public void SaveChests(ChestsData chestsData)
    { 
        _chestsData = chestsData;
        Debug.Log(_chestsData.ChestsList.Count);
       Debug.Log($"<color=yellow> SAVE CHESTS DATA </color>");
    }
}
