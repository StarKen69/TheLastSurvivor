using UnityEngine;

[CreateAssetMenu(fileName = "GameItem", menuName = "Game Item")]
public class GameItem : ScriptableObject {
    public new string name = "";
    public string description;
    public int weight = 1;
    public Sprite icon;
    public ItemType type;
    public GameObject prefab;
    public GameObject dropPrefab;

    public enum ItemType
    {
        TEST_ITEM_1, TEST_ITEM_2, TEST_ITEM_3
    }
}
