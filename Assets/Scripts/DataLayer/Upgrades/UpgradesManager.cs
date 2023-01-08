using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerUpgrade;

    public PlayerInfo PlayerUpgrade
    {
        get 
        { 
            return _playerUpgrade; 
        } 
    }
}
