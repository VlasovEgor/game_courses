using System;

public class InventoryItemEffectController : IInventoryItemObserver
{
   // private CharacterService _heroService;
   //
   // public void Construct(CharacterService characterService)
   // {
   //     _heroService= characterService;
   // }

    public void OnAddItem(InventoryItem inventoryItem)
    {
        if((inventoryItem.Flags & InventoryItemFlags.EFFECTITBLE) == InventoryItemFlags.EFFECTITBLE)
        {
            ActivateEffect(inventoryItem);
        }
    }

    public void OnRemoveItem(InventoryItem inventoryItem)
    {
        if ((inventoryItem.Flags & InventoryItemFlags.EFFECTITBLE) == InventoryItemFlags.EFFECTITBLE)
        {
            DeactivateEffect(inventoryItem);
        }
    }

    private void ActivateEffect(InventoryItem inventoryItem)
    {
      //  IEffect effect = inventoryItem.GetComponent<IGetEffectComponent>().Effect;

       // var hero = _heroService.GetCharacter();
        //var heroComponent = hero.Get<IEffectorComponent>();
       // heroComponent.AddEffect(effect);
    }

    private void DeactivateEffect(InventoryItem inventoryItem)
    {
       // IEffect effect = inventoryItem.GetComponent<IGetEffectComponent>().Effect;

       // var hero = _heroService.GetCharacter();
        //var heroComponent = hero.Get<IEffectorComponent>();
       // heroComponent.RemoveEffect(effect);
    }
}
