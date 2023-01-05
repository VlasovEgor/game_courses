using UnityEngine;

public class MenuPlatform : MonoBehaviour, IConstructListener
{
    [SerializeField] private EventReceiver_Trigger _platformTrigger;
    [SerializeField] private StorageComponent _platformComponent;

    private IngredientShower _ingredientShower;

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
        _ingredientShower = context.GetService<IngredientShower>();
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            _ingredientShower.ShowStorage(_platformComponent);
        }
    }

}