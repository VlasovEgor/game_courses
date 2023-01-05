using UnityEngine;

public class MenuFactory : MonoBehaviour,IConstructListener
{
    [SerializeField] private EventReceiver_Trigger _platformTrigger;

    private FactoryShower _factoryShower;

    private void OnEnable()
    {
        _platformTrigger.OnTriggerEntered += OnTriggerEntered;
    }

    private void OnDisable()
    {
        _platformTrigger.OnTriggerEntered -= OnTriggerEntered;
    }

    public void Construct(GameContext context)
    {
        _factoryShower = context.GetService<FactoryShower>();
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            _factoryShower.ShowWarehouse();

        }
    }
}
