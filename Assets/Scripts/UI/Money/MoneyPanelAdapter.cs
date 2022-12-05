using Sirenix.OdinInspector;
using UnityEngine;

public class MoneyPanelAdapter : MonoBehaviour,IConstructListener,IStartGameListener,IFinishGameListener
{
    [SerializeField] private MoneyPanel _moneyPanel;

    private MoneyStorage _moneyStorage;

    public void Construct(GameContext context)
    {
        _moneyStorage = context.GetService<MoneyStorage>();
        _moneyPanel.SetupMoney(_moneyStorage.Money.ToString());
    }

    public void OnStartGame()
    {
        _moneyStorage.OnMoneyChanged += OnMoneyChanged;
    }

    public void OnFinishGame()
    {
        _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(BigNumber money)
    {
        _moneyPanel.UpdateMoney(money.ToString());
        Debug.Log(money);
    }


}
