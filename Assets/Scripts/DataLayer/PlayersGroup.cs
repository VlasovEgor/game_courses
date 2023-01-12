using System;
using UnityEngine;

public class PlayersGroup : MonoBehaviour
{
    [SerializeField] private PlayerConfig[] _players;

    public PlayerConfig[] Players
    { 
        get 
        { 
            return _players;
        } 
    }

    private void Awake()
    {
        _players = FindObjectsOfType<PlayerConfig>();
        SetPlayersID();
    }

    private void SetPlayersID()
    {
        for (var i = 0; i < _players.Length; i++)
        {
            var config = _players[i];
            config.PlayerID = i;
        }
    }
}