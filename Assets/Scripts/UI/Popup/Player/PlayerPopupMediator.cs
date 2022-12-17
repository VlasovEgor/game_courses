using UnityEngine;

public class PlayerPopupMediator : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    [SerializeField] private PlayerPopup _playerPopup;
    [SerializeField] private SaveLoadUpgrade _saveLoadUpgrade;

    public void OnStartGame()
    {
        _saveLoadUpgrade.OnLoadUpgrade += LevelUpdate;
    }

    public void OnFinishGame()
    {
        _saveLoadUpgrade.OnLoadUpgrade -= LevelUpdate;
    }

    private void LevelUpdate()
    {
        _playerPopup.UpdatingStatsAfterLoading();
    }
}