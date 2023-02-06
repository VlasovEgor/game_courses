using Sirenix.OdinInspector;
using UnityEngine;

public class InventoryTest: MonoBehaviour, IConstructListener
{
    [ShowInInspector, ReadOnly] private readonly Inventory _inventory= new();
    [ShowInInspector, ReadOnly] private readonly Equipment _equipment = new();

    private readonly EquipmentItemRecipient _itemRecipient= new();
    private readonly InventoryItemEffectController _effectController= new();

    public void Construct(GameContext context)
    {
        _effectController.Construct(context.GetService<CharacterService>());

        _equipment.AddListener(_effectController);
        _itemRecipient.Construct(_inventory, _equipment);
    }

    [Button]
    public void AddItemInventory(InventoryItemConfig itemConfig)
    {
        var item = itemConfig.Protatype.Clone();
        _inventory.AddItem(item);
    }

    [Button]
    public void RemoveItemInventory(InventoryItemConfig itemConfig) 
    {
        _inventory.RemoveItem(itemConfig.Protatype.Name);
    }

    [Button]
    public void AddItemEquip(InventoryItemConfig itemConfig)
    {
        var item = itemConfig.Protatype;
        _itemRecipient.PutOnEquipment(item);
    }

    [Button]
    public void RemoveItemEquip(InventoryItemConfig itemConfig)
    {
        _itemRecipient.RemoveEquipment(itemConfig.Protatype);
    }
}

