using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public PlayerBase playerBase;
    public PlayerMovement playerMovement;
    public GameObject inventoryUI;
    public Transform inventorySlotsContainer;
    public GameObject itemsRowPrefab, itemSlotPrefab;
    public Text healthText, foodText;

    private bool inventoryOpened;

    public void Awake()
    {
        playerBase.OnPlayerPropertiesChanged += OnPlayerPropertiesChanged;
    }

    public void Update()
    {
        // When press 'E', open (and load) or close player inventory
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!inventoryOpened) LoadInventory(playerBase.GetInventory());
            inventoryOpened = !inventoryOpened;
            inventoryUI.SetActive(inventoryOpened);

            // Remove or reactive player moving control
            playerMovement.canMove = !inventoryOpened;
        }
    }

    public void RefreshPlayerInfoPanel()
    {
        healthText.text = playerBase.GetHealth() + " %";
        foodText.text = playerBase.GetFood() + " / " + PlayerBase.PLAYER_MAX_FOOD;
    }

    private void OnPlayerPropertiesChanged(PlayerBase player)
    {
        RefreshPlayerInfoPanel();
    }

    private void LoadInventory(InventoryBase inventory)
    {
        // Remove all childs (items rows)
        foreach (Transform child in inventorySlotsContainer) Destroy(child.gameObject);

        int i = 7, b = 1;
        int contentY = 0;
        GameObject currentItemsRow = null;
        foreach(InventorySlot slot in inventory.GetSlots())
        {
            // Each 6 slots...
            if(i > 6)
            {
                // Create a new items row
                currentItemsRow = Instantiate(itemsRowPrefab);
                currentItemsRow.name = "ItemsRow";
                currentItemsRow.transform.SetParent(inventorySlotsContainer, false);
                b++;
                contentY -= 55;
                i = 1;
            }

            // Create an item slot
            GameObject itemSlot = Instantiate(itemSlotPrefab);
            itemSlot.name = "ItemSlot";
            itemSlot.transform.GetChild(0).GetComponent<Image>().sprite = slot.inventoryItem.GetGameItem().icon;
            itemSlot.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = slot.inventoryItem.amount.ToString();
            itemSlot.transform.SetParent(currentItemsRow.transform);
            itemSlot.transform.localScale = Vector3.one;

            i++;
        }
        inventorySlotsContainer.GetComponent<RectTransform>().offsetMin = new Vector2(0, contentY);
    }
}
