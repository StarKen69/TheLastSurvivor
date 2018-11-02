using UnityEngine;

public class PlayerInventory : InventoryBase {
    public delegate void DropItemEvent();
    public static event DropItemEvent OnDropItem;

    public void DropItem(int index)
    {
        InventoryItem item = GetItem(index);
        GameObject dropObj = Instantiate(item.item.dropPrefab, transform.position, Quaternion.identity);

        Rigidbody dropRb = dropObj.GetComponent<Rigidbody>();
        dropRb.AddRelativeForce(transform.forward * 10, ForceMode.VelocityChange);
        RemoveItem(index);

        Debug.Log("Item dropped at index " + index);

        if(OnDropItem != null) OnDropItem();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ItemDrop>() != null)
        {
            ItemDrop itemDrop = collision.gameObject.GetComponent<ItemDrop>();
            if(itemDrop.isPickeable() && CheckWeight(itemDrop.item.weight))
            {
                AddItem(new InventoryItem(itemDrop.item, itemDrop.amount));
                Destroy(collision.gameObject);
            }
        }
    }
}
