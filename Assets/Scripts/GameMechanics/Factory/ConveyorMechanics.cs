using Elementary;
using UnityEngine;
using Sirenix.OdinInspector;

public class ConveyorMechanics : MonoBehaviour
{
    [SerializeField] private TimerBehaviour _workTimer;
    [SerializeField] private LimitedIntBehavior _outputStorage;
    [SerializeField] private ConveyorRecipes _conveyorRecipes;
    [SerializeField] private IngredientDeliverer _ingredientDeliverer;
    [SerializeField] private UnloadZoneVisual _unloadZoneVisual;

    private Recipe _currentRecipe;

    private void OnEnable()
    {
        _workTimer.OnEnded += OnWorkFinished;
        _ingredientDeliverer.OnStartWork += StartWork;
    }

    private void OnDisable()
    {
        _workTimer.OnEnded -= OnWorkFinished;
        _ingredientDeliverer.OnStartWork -= StartWork;
    }

    [Button]
    private void TryStartWork(Recipes recipes)
    {
        if (_outputStorage.IsLimit || _workTimer.IsPlaying)
        {
            Debug.Log("conveyor is busy");
            return;
        }

        for (int i = 0; i < _conveyorRecipes._Recipes.Length; i++)
        {
            if(recipes == _conveyorRecipes._Recipes[i].RecipeType)
            {
                _currentRecipe = _conveyorRecipes._Recipes[i];
                _ingredientDeliverer.RequestIngredients?.Invoke(_conveyorRecipes._Recipes[i]);
                
                Debug.Log($"<color=green>RECIPE TYPE {recipes}  FOUND</color>");
                return;
            }
        }

        Debug.Log($"<color=red>RECIPE TYPE {recipes} NOT FOUND</color>");
    }

    public void StartWork()
    {
        _workTimer.ResetTime();
        _workTimer.Duration = _currentRecipe.ProductionTime();
        _workTimer.Play();
        
        Debug.Log("–¿¡Œ“¿ Õ¿◊¿“¿");
    }

    private void OnWorkFinished()
    {
        _unloadZoneVisual.Items[_unloadZoneVisual.CurrentAmount].GetComponent<MeshRenderer>().material = _currentRecipe.GetMaterial();
        _outputStorage.Value++;
        _unloadZoneVisual.SetupItems(_outputStorage.Value);
        Debug.Log("–¿¡Œ“¿ «¿ ŒÕ◊≈Õ¿");
    }
}