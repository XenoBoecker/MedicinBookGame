using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string HerbName;
    public int Amount;

    public void UseIngredient(int amount)
    {
        if (Amount >= amount)
        {
            Amount -= amount;
            Debug.Log($"{amount} of {HerbName} used.");
        }
        else
        {
            Debug.Log($"Not enough {HerbName}.");
        }
    }

    public void AddIngredient(int amount)
    {
        Amount += amount;
        Debug.Log($"{amount} of {HerbName} added.");
    }
}
