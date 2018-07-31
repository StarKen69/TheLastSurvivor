using UnityEngine;
using System.Collections.Generic;

public class InventoryBase : MonoBehaviour
{
    public InventoryType inventoryType;
    private List<InventorySlot> slots = new List<InventorySlot>();
    private int maxSlots;

    public void SetSlotSize(int slots)
    {
        maxSlots = slots;
    }

    public void AddItem(InventoryItem item)
    {
        AddItem(item, slots.Count + 1);
    }

    public void AddItem(InventoryItem item, int slotOrder)
    {
        AddItem(item.GetGameItem(), slotOrder, item.amount);
    }

    public void AddItem(GameItem item)
    {
        AddItem(item, slots.Count + 1);
    }

    public void AddItem(GameItem item, int slotOrder)
    {
        AddItem(item, slotOrder, 1);
    }

    public void AddItem(GameItem item, int slotOrder, int amount)
    {
        if (slots.Count < maxSlots)
        {
            if (slotOrder >= 1 && slotOrder <= maxSlots)
            {
                foreach (InventorySlot slot in slots)
                {
                    if (slotOrder == slot.order)
                    {
                        if (slot.inventoryItem.GetGameItem().type == item.type)
                        {
                            Debug.Log("Item amount changed! On slot " + slotOrder + ", item: '" + item.name + "'; from " + slot.inventoryItem.amount + " to " + (slot.inventoryItem.amount + amount));
                            slot.inventoryItem.amount += amount;
                        }
                        else Debug.LogWarning("The slot is already occupied by an other item (" + slotOrder + ")");
                        return;
                    }
                }

                slots.Add(new InventorySlot(slotOrder, ScriptableObject.CreateInstance<InventoryItem>().Initialize(item, amount)));
                Debug.Log("Item '" + item.name + "' added into slot " + slotOrder + " with an amount of " + amount);
            }
            else Debug.LogWarning("Slot order out of range (must be between 1 to " + maxSlots + ")");
        }
        else Debug.LogWarning("Item not added ('" + item.name + "'). The inventory is full.");
    }

    public List<InventorySlot> GetSlots()
    {
        return slots;
    }

    public InventorySlot GetSlot(int order)
    {
        if (order >= 1 && order <= maxSlots)
        {
            InventorySlot res = null;
            foreach (InventorySlot slot in slots)
                if (slot.order == order) res = slot;
            return res;
        }

        Debug.LogWarning("Slot order out of range (must be between 1 to " + maxSlots + ")");
        return null;
    }
}

public enum InventoryType
{
    PLAYER_INVENTORY
}

public class InventorySlot
{
    public readonly int order = 1;
    public readonly InventoryItem inventoryItem;

    public InventorySlot(int order, InventoryItem inventoryItem)
    {
        this.order = order;
        this.inventoryItem = inventoryItem;
    }
}

public class InventoryItem : ScriptableObject
{
    private GameItem gameItem;
    public int amount;

    public InventoryItem Initialize(GameItem gameItem, int amount)
    {
        this.gameItem = gameItem;
        this.amount = amount;
        return this;
    }

    public GameItem GetGameItem()
    {
        return gameItem;
    }
}
