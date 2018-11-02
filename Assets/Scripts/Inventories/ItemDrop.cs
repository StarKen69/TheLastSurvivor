using UnityEngine;

public class ItemDrop : MonoBehaviour {
    public GameItem item;
    public int amount = 1;

    private bool pickeable;
    private bool temp_val;

    public void Start()
    {
        Invoke("InvokedSetPickeable", 1);
    }

    public void SetPickeable(bool value = true)
    {
        pickeable = value;
    }

    public bool isPickeable()
    {
        return pickeable;
    }

    private void InvokedSetPickeable()
    {
        pickeable = true;
    }
}
