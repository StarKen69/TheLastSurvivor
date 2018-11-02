using UnityEngine;
using System.Collections.Generic;

public class CraftInventory : InventoryBase {
    public List<CraftRecipe> recipes = new List<CraftRecipe>();

    /*
    public InventoryItem CraftRecipe(List<InventoryItem> ingredients)
    {
        InventoryItem res = null;
        List<InventoryItem> usedIngredients = new List<InventoryItem>();
        foreach(CraftRecipe recipe in recipes)
        {
            int foundEnoughIngredients = 0;
            foreach(CraftRecipeIngredient recipeIngredient in recipe.ingredients)
            {
                int foundAmount = 0;
                foreach(InventoryItem ingredient in ingredients)
                {
                    if (recipeIngredient.gameItem.type == ingredient.GetGameItem().type)
                    {
                        foundAmount += ingredient.amount;

                        if (foundAmount >= recipeIngredient.amount)
                        {
                            usedIngredients.Add(ingredient);
                            foundEnoughIngredients++;
                            break;
                        } else
                        {
                            Debug.LogWarning("Not enough ingredients for this recipe ('" + recipeIngredient.gameItem.name + "', " + (recipeIngredient.amount - foundAmount) + " more of this needed).");
                            return null;
                        }
                    }
                }

                if(foundAmount == 0)
                {
                    Debug.LogWarning("No recipe found with those ingredients");
                    return null;
                }
            }

            if (foundEnoughIngredients == recipe.ingredients.Count)
            {
                res = ScriptableObject.CreateInstance<InventoryItem>().Initialize(recipe.resultItem, recipe.resultAmount);
                AddItem(res);
                Debug.Log("Item crafted ('" + res.GetGameItem().name + "', with an amount of " + res.amount + ")");
                break;
            }
        }
        return res;
    }
    */
}
