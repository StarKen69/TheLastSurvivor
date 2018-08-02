using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventoryBase {
    public const int PLAYER_INVENTORY_SLOTS = 18;

    public void Start()
    {
        SetSlotSize(PLAYER_INVENTORY_SLOTS);
    }
}
