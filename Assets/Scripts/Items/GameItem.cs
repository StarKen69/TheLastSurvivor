using UnityEngine;

[CreateAssetMenu(fileName = "GameItem", menuName = "Game Item")]
public class GameItem : ScriptableObject {
    public new string name = "";
    public string description;
    public Sprite icon;
    public GameItemType type;
    public GameObject prefab;

    public enum GameItemType
    {
        TEST_ITEM_1, TEST_ITEM_2, TEST_ITEM_3
    }
}
