using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemUI : MonoBehaviour {
    public Text amountUI;
    public Image iconUI;

    private InventoryItem item;
    private InventoryUI inventoryUI;
    private Transform gameUITransform;
    private PlayerBase playerBase;
    private float offsetX, offsetY;
    private Transform initialParent;
    private Vector3 initialPosition;

    public void Start()
    {
        playerBase = GameObject.Find("Player").GetComponent<PlayerBase>();
        gameUITransform = GameObject.Find("Canvas/Game").transform;
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
        amountUI.text = item.amount.ToString();
        iconUI.sprite = item.item.icon;
    }

    public void OnBeginDrag()
    {
        inventoryUI.SetDraggedInventoryItem(this);

        initialParent = transform.parent;
        initialPosition = transform.position;

        transform.SetParent(gameUITransform);

        offsetX = transform.position.x - Input.mousePosition.x;
        offsetY = transform.position.y - Input.mousePosition.y;
    }

    public void OnDrag()
    {
        transform.position = new Vector2(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
    }

    public void OnEndDrag(BaseEventData data)
    {
        transform.position = initialPosition;

        transform.SetParent(initialParent);

        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.hovered.Count == 0)
        {
            playerBase.GetInventory().DropItem(item.index);
        }

        inventoryUI.SetDraggedInventoryItem(null);
        inventoryUI.RefreshUI();
    }
}
