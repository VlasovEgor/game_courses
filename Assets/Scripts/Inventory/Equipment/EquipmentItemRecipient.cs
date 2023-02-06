using UnityEngine;
using System;

public class EquipmentItemRecipient
{
    private Inventory _inventory;
    private Equipment _equipment;

    public void Construct(Inventory inventory, Equipment equipment)
    {
        _inventory = inventory;
        _equipment = equipment;
    }


    public void PutOnEquipment(InventoryItem inventoryItem)
    {

        if(CanPutOnEquipment(inventoryItem)==false)
        {
            throw new Exception($"Can not equip item {inventoryItem.Name}");
        }

        _equipment.AddItem(inventoryItem);
        _inventory.RemoveItem(inventoryItem.Name);
        
    }

    public void RemoveEquipment(InventoryItem inventoryItem)
    {
        var equipTypeItem = inventoryItem.GetComponent<EquipTypeComponent>();

        if (_equipment.Items.ContainsKey(equipTypeItem.Type)==true)
        {
            _equipment.RemoveItem(inventoryItem);
            _inventory.AddItem(inventoryItem);
        }
    }

    private bool CanPutOnEquipment(InventoryItem inventoryItem)
    {
       var equipTypeItem = inventoryItem.GetComponent<EquipTypeComponent>();

        
        return (inventoryItem.Flags & InventoryItemFlags.EQIPPABLE) == InventoryItemFlags.EQIPPABLE &&
            // _inventory.IsItemExists(inventoryItem) &&      for some reason it doesn't work with this
            _equipment.Items.ContainsKey(equipTypeItem.Type) ==false;
    }
}
