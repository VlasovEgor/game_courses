using System;
using UnityEngine;

public class PlayerPresentationModel : IPlayerPresentationModel
{
    public event Action<bool> OnBuyButtonStateChanged;

    private readonly PlayerInfo _player;
    private readonly PlayerUpgrader _playerUpgrader;
    private readonly MoneyStorage _moneyStorage;

    public PlayerPresentationModel(PlayerInfo player, PlayerUpgrader playerUpgrader, MoneyStorage moneyStorage)
    {
        _player=player;
        _playerUpgrader=playerUpgrader; 
        _moneyStorage=moneyStorage; 
    }

    public void Start()
    {
        _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        _playerUpgrader.OnPlayerUpgraded += OnPlayerUpgraded;
    }

    private void OnPlayerUpgraded()
    {
        //тут должен быть прикол с обновлением данныхв в popup'e
    }

    public void Stop()
    {
        _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        _playerUpgrader.OnPlayerUpgraded += OnPlayerUpgraded;
    }

    private void OnMoneyChanged(int obj)
    {
        var canBuy = _playerUpgrader.CanUpgrade(_player);
        OnBuyButtonStateChanged?.Invoke(canBuy);
    }

    string IPlayerPresentationModel.GetPlayerName()
    {
        return _player.Name;
    }

    string IPlayerPresentationModel.GetDamage()
    {
        return "Damage: " + _player.Damage;
    }

    string IPlayerPresentationModel.GetHealthPoints()
    {
        return "HitPoints: " + _player.HealthPoints;
    }

    Sprite IPlayerPresentationModel.GetIcon()
    {
        return _player.Icon;
    }

    string IPlayerPresentationModel.GetLevel()
    {
        return "Level: " + _player.Level;
    }

    string IPlayerPresentationModel.GetPrice()
    {
        return _player.Price.ToString();
    }

    void IPlayerPresentationModel.OnBuyClicked()
    {
        _playerUpgrader.Upgrade(_player);
    }

    bool IPlayerPresentationModel.CanBuy()
    {
        return _playerUpgrader.CanUpgrade(_player);
    }
}