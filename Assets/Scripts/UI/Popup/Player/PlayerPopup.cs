using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPopup : Popup
{
    [SerializeField] private TextMeshProUGUI _playerName;

    [SerializeField] private TextMeshProUGUI _levelText;

    [SerializeField] private TextMeshProUGUI _healthPointsText;

    [SerializeField] private TextMeshProUGUI _damageText;

    [SerializeField] private Image _iconImage;

    [SerializeField] private BuyButton _buyButton;


    private IPlayerPresentationModel _presenter;

    protected override void OnShow(object args)
    {
        if (args is not IPlayerPresentationModel presenter)
        {
            throw new Exception("Expected Presentation model!");
        }

        _presenter = presenter;
        _presenter.Start();

        _buyButton.AddListener(OnBuyButtonClicked);
        _presenter.OnLevelUp += UpdatePLayerStats;

        UpdatePLayerStats();
    }

    protected override void OnHide()
    {
        _buyButton.RemoveListener(OnBuyButtonClicked);
        _presenter.OnBuyButtonStateChanged -= OnBuyButtonStateChanged;
        _presenter.OnLevelUp -= UpdatePLayerStats;
        _presenter.Stop();
    }

    private void UpdatePLayerStats()
    {
        _presenter.OnBuyButtonStateChanged += OnBuyButtonStateChanged;

        _playerName.text = _presenter.GetPlayerName();
        _levelText.text = _presenter.GetLevel();
        _healthPointsText.text = _presenter.GetHealthPoints();
        _damageText.text = _presenter.GetDamage();
        _iconImage.sprite = _presenter.GetIcon();

        _buyButton.SetPrice(_presenter.GetPrice());
        _buyButton.SetAvailable(_presenter.CanBuy());
    }

    private void OnBuyButtonStateChanged(bool isAvailabe)
    {
        _buyButton.SetAvailable(isAvailabe);
    }

    private void OnBuyButtonClicked()
    {
        _presenter.OnBuyClicked();
    }
}
