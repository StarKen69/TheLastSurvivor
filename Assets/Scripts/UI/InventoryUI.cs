using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    public Text titleUI, capacityUI;
    public Transform itemsContainerUI;
    public GameObject inventoryItemUIPrefab;

    private float offsetX, offsetY;
    private InventoryBase loadedInventory;
    private InventoryItemUI draggedInventoryItemUI;

    public void Start()
    {
        PlayerInventory.OnDropItem += RefreshUI;
    }

    public void OnEnable()
    {
        RefreshUI();
    }

    public void SetDraggedInventoryItem(InventoryItemUI item)
    {
        draggedInventoryItemUI = item;
    }

    public InventoryItemUI GetDraggedInventoryItem()
    {
        return draggedInventoryItemUI;
    }

    public bool SetVisible()
    {
        return SetVisible(!gameObject.activeInHierarchy);
    }

    public bool SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
        return IsVisible();
    }

    public bool IsVisible()
    {
        return gameObject.activeInHierarchy;
    }

    public void SetInventory(InventoryBase inventory)
    {
        loadedInventory = inventory;
    }

    public InventoryBase GetInventory()
    {
        return loadedInventory;
    }

    private void LoadInventory()
    {
        Clear();

        foreach (InventoryItem inventoryItem in loadedInventory.GetItems())
        {
            GameObject obj = Instantiate(inventoryItemUIPrefab);
            obj.name = inventoryItemUIPrefab.name;
            obj.transform.SetParent(itemsContainerUI);
            obj.transform.localScale = Vector3.one;

            InventoryItemUI inventoryItemUI = obj.GetComponent<InventoryItemUI>();
            inventoryItemUI.SetItem(inventoryItem);
        }
    }

    public void RefreshUI()
    {
        titleUI.text = loadedInventory.name;
        capacityUI.text = loadedInventory.GetWeight() + " / " + loadedInventory.GetMaxWeight();
        LoadInventory();
    }

    public void Clear()
    {
        foreach (Transform child in itemsContainerUI)
            Destroy(child.gameObject);
    }

    public void OnBeginDrag()
    {
        offsetX = transform.position.x - Input.mousePosition.x;
        offsetY = transform.position.y - Input.mousePosition.y;
    }

    public void OnDrag()
    {
        transform.position = new Vector2(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
    }
}
