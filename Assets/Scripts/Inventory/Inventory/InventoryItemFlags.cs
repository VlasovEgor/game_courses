using System;

[Flags]
public enum InventoryItemFlags
{
    NONE=0,
    STACKABLE=1,
    CONSUMABLE=2,
    EQIPPABLE=4,
    EFFECTITBLE=8
}