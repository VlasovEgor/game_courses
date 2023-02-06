public interface IInventoryItemObserver
{
    void OnAddItem(InventoryItem inventoryItem);

    void OnRemoveItem(InventoryItem inventoryItem);
}