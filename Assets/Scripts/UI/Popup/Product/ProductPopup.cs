using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductPopup : Popup,IConstructListener
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _decripttionText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Button _buyButton;

    private MoneyStorage _moneyStorage;

    public void Construct(GameContext context)
    {
        _moneyStorage = context.GetService<MoneyStorage>();
    }

    protected override void OnShow(object args)
    {
        if (args is not ProductInfo product)
        {
            throw new Exception("Expected product");
        }

        _titleText.text = product.Title;
        _decripttionText.text = product.Description;
        _iconImage.sprite = product.Icon;

        _moneyStorage.OnMoneyChanged += OnMoneyChanged;
    }

    protected override void OnHide()
    {
        _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(BigNumber obj)
    {

    }
}
