using UnityEngine;
using System.Collections.Generic;

public class InventoryBase : MonoBehaviour {
    public new string name = "Inventory";
    public int maxWeight = 30;

    private List<InventoryItem> items = new List<InventoryItem>();
    private int currentWeight = 0;

    public void AddItem(InventoryItem item)
    {
        if (!CheckWeight(item.item.weight * item.amount))
        {
            Debug.LogWarning("The inventory is full");
            return;
        }

        InventoryItem foundItem = null;

        foreach(InventoryItem savedItem in items) {
            if(savedItem.index == item.index)
            {
                foundItem = savedItem;
            }
        }

        if (foundItem != null)
        {
            if (foundItem.item.type == item.item.type)
            {
                foundItem.amount += item.amount;
                Debug.Log("Item already exists in that slot. Amount changed to " + foundItem.amount);
            }
            else
            {
                Debug.LogWarning("The slot is already occupied by an other item");
            }
        }
        else
        {
            items.Add(item);
        }

        currentWeight += item.item.weight * item.amount;
    }

    public void RemoveItem(int index)
    {
        foreach(InventoryItem item in items)
        {
            if (item.index == index)
            {
                items.Remove(item);
                currentWeight -= item.item.weight * item.amount;
                break;
            }
        }
    }

    public List<InventoryItem> GetItems()
    {
        return items;
    }

    public InventoryItem GetItem(int index)
    {
        return items[index];
    }

    public void SetWeight(int weight)
    {
        currentWeight = weight;
    }

    public int GetWeight()
    {
        return currentWeight;
    }

    public int GetMaxWeight()
    {
        return maxWeight;
    }

    protected bool CheckWeight(int weight)
    {
        return currentWeight + weight < maxWeight;
    }
}

public class InventoryItem
{
    public GameItem item;
    public int amount = 1;
    public int index = 0;

    public InventoryItem(GameItem item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
