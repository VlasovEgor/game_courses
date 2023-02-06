using System;
using UnityEngine;

[CreateAssetMenu(
    fileName ="Inventory Item",
    menuName ="Inventory/New Inventory Item"
    )]

public class InventoryItemConfig : ScriptableObject
{
    [SerializeField] public InventoryItem Protatype;

}