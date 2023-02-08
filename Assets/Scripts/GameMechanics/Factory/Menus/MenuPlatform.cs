using UnityEngine;

public class MenuPlatform : MonoBehaviour, IConstructListener
{
    [SerializeField] private EventReceiver_Trigger _platformTrigger;
    [SerializeField] private Storage _storage;

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
            _ingredientShower.ShowStorage(_storage);
        }
    }

}