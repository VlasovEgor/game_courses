using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Gameplay/ Recipe")]
public class Recipe : ScriptableObject
{
    public Recipes RecipeType;
    public Dictionary<Ingredients, WarehouseCollector> RecipeDictionary = new Dictionary<Ingredients, WarehouseCollector>();

    [Space]
    [SerializeField] private Material _productMaterial;
    [SerializeField] private float _productionTime;

    public Material GetMaterial()
    {
        return _productMaterial;
    }

    public float ProductionTime()
    { 
        return _productionTime; 
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


        Debug.Log($"����������� {RecipeDictionary[type].TypeIngredient} � ������� {RecipeDictionary[type].AmountIngredient}  ����");
    }

    [Button]
    public void TryRemoveIngredient(Ingredients type)
    {
        if (RecipeDictionary.ContainsKey(type) == true)
        {
            Debug.Log($"���������� {RecipeDictionary[type].TypeIngredient} ���˨�");
            RecipeDictionary.Remove(type);    
        }
        else
        {
            Debug.Log("������ ����������� � �� ����");
        }
    }

    [Button]
    public void ShowIngredients()
    {
        foreach (WarehouseCollector currentIngredient in RecipeDictionary.Values)
        {
            Debug.Log($"��� �������� ������� ����� {currentIngredient.AmountIngredient} ���� {currentIngredient.TypeIngredient}");
        }
    }
}