using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemSlotUI : MonoBehaviour {
    public Image iconUI;
    public Text amountUI;

    private InventoryItem item;
    private InventoryUI inventoryUI;

    public void Awake()
    {
        inventoryUI = GameObject.Find("Canvas/Game/InventoryUI").GetComponent<InventoryUI>();
    }

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        RefreshUI();
    }

    public InventoryItem GetItem()
    {
        return item;
    }

    public void RefreshUI()
    {
        iconUI.sprite = item.item.icon;
        amountUI.text = item.amount.ToString();
    }

    public void OnDrop(BaseEventData data)
    {
        InventoryItemUI droppedItemUI = inventoryUI.GetDraggedInventoryItem();
        InventoryItem droppedItem = droppedItemUI.GetItem();

        SetItem(droppedItem);
    }
}
