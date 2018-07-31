using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : CraftInventory {
    public GameItem item1, item2;
    public const int PLAYER_INVENTORY_SLOTS = 18;

    public void Start()
    {
        SetSlotSize(PLAYER_INVENTORY_SLOTS);
        AddItem(item1);
        AddItem(item2);

        List<InventoryItem> ingredients = new List<InventoryItem>() {
            { GetSlot(1).inventoryItem }, { GetSlot(2).inventoryItem }
        };
        InventoryItem craftedItem = CraftRecipe(ingredients);
    }
}
