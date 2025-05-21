using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    private List<string> selectedIngredients = new List<string>();

    public void SelectIngredient(Ingredient ingredient)
    {
        if (selectedIngredients.Count >= 3)
        {
            Debug.Log("Mortar is full.");
            return;
        }

        if(ingredient.Amount <= 0)
        {
            Debug.Log($"No {ingredient.HerbName} in inventory.");
            return;
        }

        ingredient.UseIngredient(1);
        selectedIngredients.Add(ingredient.HerbName);
        Debug.Log($"Added {ingredient.HerbName} to the mortar.");
    }

    public void CraftPotion()
    {
        if (selectedIngredients.Count == 0)
        {
            Debug.Log("No ingredients selected.");
            return;
        }

        Potion newPotion = new Potion(new List<string>(selectedIngredients));
        inventoryManager.AddPotion(newPotion);

        Debug.Log($"Crafted a potion with: {string.Join(", ", selectedIngredients)}");

        selectedIngredients.Clear();
    }

    public void ClearMortar()
    {
        // Return herbs back to inventory if needed
        foreach (var herb in selectedIngredients)
        {
            inventoryManager.AddHerb(herb, 1);
        }

        selectedIngredients.Clear();
        Debug.Log("Mortar cleared.");
    }
}
