using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public InventoryUI inventoryUI;

    public PlayerBase playerBase;
    public Text healthText, foodText;

    private bool inventoryOpened;

    public void Awake()
    {
        playerBase.OnPlayerPropertiesChanged += OnPlayerPropertiesChanged;
    }

    public void Update()
    {
        // When press 'E', open and load (or close) player inventory
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!inventoryUI.IsVisible())
            {
                inventoryUI.SetInventory(playerBase.GetInventory());
            }
            inventoryUI.SetVisible();
        }


        // If I press one number from 1 to 9, select the relative slot in the
        // inventory fast select bar
        for (int i = 1; i <= 9; ++i)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                Debug.Log("Number " + i + " pressed");
                break;
            }
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
}
