using Sirenix.OdinInspector;
using UnityEngine;

public class FactoryShower : MonoBehaviour, IConstructListener
{
    private PopupManager _popupManager;
    private FactoryPresentationModelFactory _presenerFactory;

    public void Construct(GameContext context)
    {
        _presenerFactory = context.GetService<FactoryPresentationModelFactory>();
        _popupManager = context.GetService<PopupManager>();
    }

    [Button]
    public void ShowWarehouse()
    {
        var presentationModel = _presenerFactory.CreatePresenter();
        _popupManager.ShowPopup(PopupName.CONVEYOR, presentationModel);
    }
}
