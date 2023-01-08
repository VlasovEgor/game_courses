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

    public PlayerConfig FindPlayer(int id)
    {
        for (var i = 0; i < _players.Length; i++)
        {
            var config = _players[i];
            if (config.PlayerID == id)
            {
                return config;
            }
        }

        throw new Exception($"Player with {id} is not found!");
    }

    public int CheckId(int numberInArray)
    {
        for (var i = 0; i < _players.Length; i++)
        {
            var config = _players[i];
            if (i == numberInArray)
            {
                return config.PlayerID;
            }
        }

        throw new Exception($"Player with {numberInArray} is not found!");
    }
}