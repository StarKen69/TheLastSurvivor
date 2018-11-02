using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftRecipe", menuName = "Craft Recipe")]
public class CraftRecipe : ScriptableObject {
    public List<CraftRecipeIngredient> ingredients;
    public GameItem resultItem;
    public int resultAmount = 1;
}

[System.Serializable]
public class CraftRecipeIngredient
{
    public GameItem gameItem;
    public int amount = 1;
}