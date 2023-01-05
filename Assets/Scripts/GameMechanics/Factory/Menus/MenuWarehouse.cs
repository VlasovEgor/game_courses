using UnityEngine;

public class MenuWarehouse : MonoBehaviour,IConstructListener
{

    [SerializeField] private EventReceiver_Trigger _platformTrigger;

    private WarehouseShower _warehouseShower;

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
        _warehouseShower = context.GetService<WarehouseShower>();
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            _warehouseShower.ShowWarehouse();

        }
    }
}
