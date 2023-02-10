using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Recipe", menuName = "Gameplay/ Recipe")]
public class Recipe : ScriptableObject
{
    public Recipes RecipeType;
    
    [ShowInInspector] public Dictionary<Ingredients, WarehouseCollector> RecipeDictionary = new();

    [Space]
    [SerializeField] private Material _productMaterial;
    [SerializeField] private Sprite _iconImage;
    [SerializeField] private float _productionTime;

    public Material GetMaterial()
    {
        return _productMaterial;
    }

    public float ProductionTime()
    {
        return _productionTime;
    }

    public Sprite IconImage
    {
        get
        {
            return _iconImage;
        }
    }

    [Button]
    public void SettingQuantityIngredient(Ingredients type, int quantity)
    {
        if (RecipeDictionary.ContainsKey(type)==false)
        {
            var recipeCollector = new WarehouseCollector
            {
                TypeIngredient = type,
                AmountIngredient = quantity,
            };
            RecipeDictionary.Add(type, recipeCollector);
        }
        else
        {
            var amountIngredient = RecipeDictionary[type];
            amountIngredient.AmountIngredient = quantity;
            RecipeDictionary[type] = amountIngredient;
        }
    }
    
    [Button]
    public void TryRemoveIngredient(Ingredients type)
    {
        if (RecipeDictionary.ContainsKey(type) == true)
        {
            RecipeDictionary.Remove(type);    
        }

    }
    
    [Button]
    public void ShowIngredients()
    {
        foreach (WarehouseCollector currentIngredient in RecipeDictionary.Values)
        {
            Debug.Log($"дкъ рейсыецн пежеорю мсфмн {currentIngredient.AmountIngredient} ьрсй {currentIngredient.TypeIngredient}");
        }
    }
}
