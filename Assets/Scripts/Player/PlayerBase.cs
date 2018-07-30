using UnityEngine;

public class PlayerBase : MonoBehaviour {
    public const int PLAYER_MAX_HEALTH = 100;
    public const int PLAYER_MAX_FOOD = 10;

    public delegate void PlayerPropertiesChanged(PlayerBase player);
    public event PlayerPropertiesChanged OnPlayerPropertiesChanged;

    private int health = 100;
    private int food = 10;

    public void SetHealth(int health)
    {
        // Limits health between 0 and 100
        if (health > PLAYER_MAX_HEALTH) health = 100;
        else if (health < 0) health = 0;
        this.health = health;

        if (OnPlayerPropertiesChanged != null) OnPlayerPropertiesChanged(this);

        if (health == 0) Die();
    }

    public void SetFood(int food)
    {
        // Limits food between 0 and 10
        if (food > PLAYER_MAX_FOOD) food = 10;
        else if (food < 0) food = 0;
        this.food = food;

        if (OnPlayerPropertiesChanged != null) OnPlayerPropertiesChanged(this);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetFood()
    {
        return food;
    }

    private void Die()
    {
        // When the player dies...
        Destroy(gameObject);
    }
}
