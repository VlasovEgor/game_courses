using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class MoneyStorage : MonoBehaviour
{
    public event Action<BigNumber> OnMoneyChanged;

    private BigNumber _money;

    public BigNumber Money 
    {
        get { return _money; }
    }

    [Button]
    public void AddMoney(BigNumber range)
    {
        _money += range;
        OnMoneyChanged?.Invoke(_money);
    }

    [Button]
    public void SpendMoney(BigNumber range)
    {
        _money -= range;
        OnMoneyChanged?.Invoke(_money);
    }
}
