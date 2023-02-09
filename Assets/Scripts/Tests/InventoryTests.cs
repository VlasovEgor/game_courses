using NUnit.Framework;

[TestFixture]
public class InventoryTests
{
   [Test]
   public void Test1()
   {   
       var bootsItem= new InventoryItem ("Boots", InventoryItemFlags.NONE, null, null);
       
   
       var inventory = new Inventory();
   
       inventory.AddItem(bootsItem);
   
   
       var isAddingSuccessful= inventory.IsItemExists(bootsItem);
       Assert.IsTrue(isAddingSuccessful);
   }
   
   [Test]
   public void Test2()
   {
       var armorItem = new InventoryItem("Armor", InventoryItemFlags.NONE, null, null);
   
       var inventory = new Inventory();
   
       inventory.AddItem(armorItem);
   
       var isAddingSuccessful = inventory.IsItemExists(armorItem);
       Assert.IsTrue(isAddingSuccessful);
   }
   
   [Test]
   public void Test3()
   {
       var crownItem = new InventoryItem("Crown", InventoryItemFlags.NONE, null, null);
   
       var inventory = new Inventory();
   
       inventory.AddItem(crownItem);
   
       var isAddingSuccessful = inventory.IsItemExists(crownItem);
       Assert.IsTrue(isAddingSuccessful);
   }
   
   [Test]
   public void Test4()
   {
       var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.NONE, null, null);
   
       var inventory = new Inventory();
   
       inventory.AddItem(magicStaffItem);
   
       var isAddingSuccessful = inventory.IsItemExists(magicStaffItem);
       Assert.IsTrue(isAddingSuccessful);
   }
   
   [Test]
   public void Test5()
   {
       var shieldItem = new InventoryItem("Shield", InventoryItemFlags.NONE, null, null);
   
       var inventory = new Inventory();
   
       inventory.AddItem(shieldItem);
   
       var isAddingSuccessful = inventory.IsItemExists(shieldItem);
       Assert.IsTrue(isAddingSuccessful);
   }

    [Test]
    public void Test6()
    {
        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.NONE, null, null);


        var inventory = new Inventory();

        inventory.AddItem(bootsItem);
        inventory.RemoveItem(bootsItem);


        var isAddingSuccessful = inventory.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test7()
    {
        var armorItem = new InventoryItem("Armor", InventoryItemFlags.NONE, null, null);

        var inventory = new Inventory();

        inventory.AddItem(armorItem);
        inventory.RemoveItem(armorItem);

        var isAddingSuccessful = inventory.IsItemExists(armorItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test8()
    {
        var crownItem = new InventoryItem("Crown", InventoryItemFlags.NONE, null, null);

        var inventory = new Inventory();

        inventory.AddItem(crownItem);
        inventory.RemoveItem(crownItem);

        var isAddingSuccessful = inventory.IsItemExists(crownItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test9()
    {
        var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.NONE, null, null);

        var inventory = new Inventory();

        inventory.AddItem(magicStaffItem);
        inventory.RemoveItem(magicStaffItem);

        var isAddingSuccessful = inventory.IsItemExists(magicStaffItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test10()
    {
        var shieldItem = new InventoryItem("Shield", InventoryItemFlags.NONE, null, null);

        var inventory = new Inventory();

        inventory.AddItem(shieldItem);
        inventory.RemoveItem(shieldItem);

        var isAddingSuccessful = inventory.IsItemExists(shieldItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test11()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(bootsItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(bootsItem);

        var isAddingSuccessful = equiip.IsItemExists(bootsItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test12()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.BODY;

        var armorItem = new InventoryItem("Armor", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(armorItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(armorItem);

        var isAddingSuccessful = equiip.IsItemExists(armorItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test13()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.HEAD;

        var crownItem = new InventoryItem("Crown", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(crownItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(crownItem);

        var isAddingSuccessful = equiip.IsItemExists(crownItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test14()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.RIGHT_HAND;


        var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(magicStaffItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(magicStaffItem);

        var isAddingSuccessful = equiip.IsItemExists(magicStaffItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test15()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEFT_HAND;


        var shieldItem = new InventoryItem("Shield", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(shieldItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(shieldItem);

        var isAddingSuccessful = equiip.IsItemExists(shieldItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test16()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(bootsItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(bootsItem);

        var isAddingSuccessful = inventory.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test17()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.BODY;

        var armorItem = new InventoryItem("Armor", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(armorItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(armorItem);

        var isAddingSuccessful = inventory.IsItemExists(armorItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test18()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.HEAD;

        var crownItem = new InventoryItem("Crown", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(crownItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(crownItem);

        var isAddingSuccessful = inventory.IsItemExists(crownItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test19()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.RIGHT_HAND;


        var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(magicStaffItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(magicStaffItem);

        var isAddingSuccessful = inventory.IsItemExists(magicStaffItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test20()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEFT_HAND;


        var shieldItem = new InventoryItem("Shield", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(shieldItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);
        equipmentRecipient.PutOnEquipment(shieldItem);

        var isAddingSuccessful = inventory.IsItemExists(shieldItem);
        Assert.IsFalse(isAddingSuccessful);
    }


    [Test]
    public void Test21()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(bootsItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(bootsItem);
        equipmentRecipient.RemoveEquipment(bootsItem);

        var isAddingSuccessful = inventory.IsItemExists(bootsItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test22()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.BODY;

        var armorItem = new InventoryItem("Armor", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(armorItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(armorItem);
        equipmentRecipient.RemoveEquipment(armorItem);

        var isAddingSuccessful = inventory.IsItemExists(armorItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test23()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.HEAD;

        var crownItem = new InventoryItem("Crown", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(crownItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(crownItem);
        equipmentRecipient.RemoveEquipment(crownItem);

        var isAddingSuccessful = inventory.IsItemExists(crownItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test24()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.RIGHT_HAND;


        var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(magicStaffItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(magicStaffItem);
        equipmentRecipient.RemoveEquipment(magicStaffItem);

        var isAddingSuccessful = inventory.IsItemExists(magicStaffItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test25()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEFT_HAND;


        var shieldItem = new InventoryItem("Shield", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(shieldItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(shieldItem);
        equipmentRecipient.RemoveEquipment(shieldItem);

        var isAddingSuccessful = inventory.IsItemExists(shieldItem);
        Assert.IsTrue(isAddingSuccessful);
    }

    [Test]
    public void Test26()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(bootsItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(bootsItem);
        equipmentRecipient.RemoveEquipment(bootsItem);

        var isAddingSuccessful = equiip.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test27()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.BODY;

        var armorItem = new InventoryItem("Armor", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(armorItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(armorItem);
        equipmentRecipient.RemoveEquipment(armorItem);

        var isAddingSuccessful = equiip.IsItemExists(armorItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test28()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.HEAD;

        var crownItem = new InventoryItem("Crown", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(crownItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(crownItem);
        equipmentRecipient.RemoveEquipment(crownItem);

        var isAddingSuccessful = equiip.IsItemExists(crownItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test29()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.RIGHT_HAND;


        var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(magicStaffItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(magicStaffItem);
        equipmentRecipient.RemoveEquipment(magicStaffItem);

        var isAddingSuccessful = equiip.IsItemExists(magicStaffItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test30()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEFT_HAND;


        var shieldItem = new InventoryItem("Shield", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();
        inventory.AddItem(shieldItem);

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(shieldItem);
        equipmentRecipient.RemoveEquipment(shieldItem);

        var isAddingSuccessful = equiip.IsItemExists(shieldItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test31()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEGS;

        var bootsItem = new InventoryItem("Boots", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(bootsItem);

        var isAddingSuccessful = equiip.IsItemExists(bootsItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test32()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.BODY;

        var armorItem = new InventoryItem("Armor", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(armorItem);

        var isAddingSuccessful = equiip.IsItemExists(armorItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test33()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.HEAD;

        var crownItem = new InventoryItem("Crown", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(crownItem);

        var isAddingSuccessful = equiip.IsItemExists(crownItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test34()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.RIGHT_HAND;


        var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(magicStaffItem);

        var isAddingSuccessful = equiip.IsItemExists(magicStaffItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test35()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEFT_HAND;


        var shieldItem = new InventoryItem("Shield", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.PutOnEquipment(shieldItem);

        var isAddingSuccessful = equiip.IsItemExists(shieldItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test36()
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

    [Test]
    public void Test37()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.BODY;

        var armorItem = new InventoryItem("Armor", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.RemoveEquipment(armorItem);

        var isAddingSuccessful = inventory.IsItemExists(armorItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test38()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.HEAD;

        var crownItem = new InventoryItem("Crown", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.RemoveEquipment(crownItem);

        var isAddingSuccessful = inventory.IsItemExists(crownItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test39()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.RIGHT_HAND;


        var magicStaffItem = new InventoryItem("MagicStaff", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.RemoveEquipment(magicStaffItem);

        var isAddingSuccessful = inventory.IsItemExists(magicStaffItem);
        Assert.IsFalse(isAddingSuccessful);
    }

    [Test]
    public void Test40()
    {
        var equipType = new EquipTypeComponent();
        equipType.Type = EquipType.LEFT_HAND;


        var shieldItem = new InventoryItem("Shield", InventoryItemFlags.EQIPPABLE, null, equipType);

        var inventory = new Inventory();

        var equiip = new Equipment();

        var equipmentRecipient = new InventoryItemEquipper();
        equipmentRecipient.Construct(inventory, equiip);

        equipmentRecipient.RemoveEquipment(shieldItem);

        var isAddingSuccessful = inventory.IsItemExists(shieldItem);
        Assert.IsFalse(isAddingSuccessful);
    }


}
