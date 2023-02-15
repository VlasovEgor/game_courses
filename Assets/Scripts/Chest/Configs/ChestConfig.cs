using System.Collections.Generic;
using UnityEngine;

public abstract class ChestConfig : ScriptableObject
{
    [SerializeField] public string Id;

    [SerializeField] public float DurationSeconds;

    [SerializeField] public List<Reward> Rewards;

    [SerializeField] public int MaxNumbersOfReward;

    [SerializeField] public int MinNumbersOfReward;

    public abstract Chest InstatiateChest(MonoBehaviour context, IGameContext gameContext);
    
}