using NUnit.Framework;
using System;

[TestFixture]
public class InventoryTests
{

    [Test]
    public void WhenInventoryIsEmpty_ByDefault()
    {
        var inventory = new Inventory();

        Assert.True(inventory.IsEmpty());
    }

    [Test]
    public void WhenAddItem_ThenInventoryShouldBeNotEmplty()
    {
        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.NONE, null, null);
        var inventory = new Inventory();
        var isItemAdded = inventory.AddItem(bootsItem);

        var isAddingSuccessful = inventory.IsItemExists(bootsItem);

        Assert.True(isItemAdded);
        Assert.IsTrue(isAddingSuccessful);
        Assert.False(inventory.IsEmpty());
    }

    [Test]
    public void WhenRemoveItem_ThenItemShouldNotBeInInventory()
    {
        var inventory = new Inventory();
        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.NONE, null, null);

        inventory.AddItem(bootsItem);
        inventory.RemoveItem(bootsItem);

        var isAddingSuccessful = inventory.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void WhenAddItemToEquipmentFromInventory_ThenItemAppearsInEquipment()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);
        var inventory = new Inventory();
        var equiip = new Equipment();
        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        inventory.AddItem(bootsItem);
        equipmentRecipient.PutOnEquipment(bootsItem);

        var isAddingSuccessful = equiip.IsItemExists(bootsItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void WhenAddItemToEuipmentFromInventory_ThenItemDisappearsFromInventory()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);
        var inventory = new Inventory();
        var equiip = new Equipment();
        var equipmentRecipient = new InventoryItemEquipper();

        inventory.AddItem(bootsItem); inventory.AddItem(bootsItem);
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(bootsItem);

        var isAddingSuccessful = inventory.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void WhenRemoveItemFromEquipment_ThenItemAppearsInInventory()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);
        var inventory = new Inventory();
        var equiip = new Equipment();
        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        inventory.AddItem(bootsItem);
        equipmentRecipient.PutOnEquipment(bootsItem);
        equipmentRecipient.RemoveEquipment(bootsItem);

        var isAddingSuccessful = inventory.IsItemExists(bootsItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void WhenRemoveItemFromEquipment_ThenItemDisappearsFromInventory()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);
        var inventory = new Inventory();
        var equiip = new Equipment();
        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        inventory.AddItem(bootsItem);
        equipmentRecipient.PutOnEquipment(bootsItem);
        equipmentRecipient.RemoveEquipment(bootsItem);

        var isAddingSuccessful = equiip.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void WhenAddItemFromEmptyInventoryToEquipment_ThenNothingAdded()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);
        var inventory = new Inventory();
        var equiip = new Equipment();
        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(bootsItem);

       Assert.Catch(typeof(Exception), () => equipmentRecipient.PutOnEquipment(bootsItem));
    }

    [Test]
    public void WhenRemoveItemFromEmptyInventory_ThenInventoryRemainsEmpty()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);
        var inventory = new Inventory();
        var equiip = new Equipment();
        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.RemoveEquipment(bootsItem);

        var isAddingSuccessful = inventory.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }
}
