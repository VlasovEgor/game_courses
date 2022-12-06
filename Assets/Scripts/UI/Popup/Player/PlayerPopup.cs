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
        UpdatePLayerStats(presenter);
        _buyButton.AddListener(OnBuyButtonClicked);
    }

    private void UpdatePLayerStats(IPlayerPresentationModel presenter)
    {
        _presenter.OnBuyButtonStateChanged += OnBuyButtonStateChanged;
        _presenter.Start();

        _playerName.text = presenter.GetPlayerName();
        _levelText.text = presenter.GetLevel();
        _healthPointsText.text = presenter.GetHealthPoints();
        _damageText.text = presenter.GetDamage();
        _iconImage.sprite = presenter.GetIcon();

        _buyButton.SetPrice(presenter.GetPrice());
        _buyButton.SetAvailable(presenter.CanBuy());
    }

    protected override void OnHide()
    {
        _buyButton.RemoveListener(OnBuyButtonClicked);
        _presenter.OnBuyButtonStateChanged -= OnBuyButtonStateChanged;
        _presenter.Stop();
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
