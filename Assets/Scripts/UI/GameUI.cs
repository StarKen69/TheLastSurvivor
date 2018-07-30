using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public PlayerBase playerBase;
    public Text healthText, foodText;

    public void Awake()
    {
        playerBase.OnPlayerPropertiesChanged += OnPlayerPropertiesChanged;
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
