using System;

public interface IWarehousePresentationModel
{
    event Action<bool> OnIncreaseButtonStateChanged;
    event Action<bool> OnDecreaseButtonStateChanged;
    event Action<bool> OnAddButtonStateChanged;

    event Action OnStatsChanged;

    IFactoryStoragesComponent GetFactoryStorages();

    string GetTitle();

    string GetAmount();

    bool CanIncrease();

    bool CanDecrease();

    bool CanAdd();

    void OnButtonSelectionClicked(Storage storage);

    void OnIncreaseClicked();

    void OnDecreaseClicked();

    void OnAddClicked();
}
