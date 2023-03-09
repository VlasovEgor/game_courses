using UnityEngine;

public class FactoryPresentationModelFactory : MonoBehaviour, IConstructListener
{
    private ObjectCreator _objectCreator;
    private IConveyorComponent _conveyorComponent;
    private IWorkComponent _workComponent;

    public void Construct(GameContext context)
    {
        _objectCreator = context.GetService<ObjectCreator>();
        _conveyorComponent = context.GetService<Conveyor>().GetComponent<IConveyorComponent>();
        _workComponent = context.GetService<Conveyor>().GetComponent<IWorkComponent>();
    }

    public FactoryPresentationModel CreatePresenter()
    {
        return new FactoryPresentationModel(_objectCreator, _conveyorComponent, _workComponent);
    }
}
