using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Plant> plantTypes;

    private Dictionary<string, int> herbInventory = new Dictionary<string, int>();
    private List<Potion> potionInventory = new List<Potion>();

    private void Start()
    {
        foreach (Plant plant in plantTypes)
        {
            herbInventory[plant.HerbProduced] = 0;
        }
    }

    public bool HasHerb(string herbName)
    {
        return herbInventory.ContainsKey(herbName) && herbInventory[herbName] > 0;
    }

    public void UseHerb(string herbName)
    {
        if (HasHerb(herbName))
        {
            herbInventory[herbName]--;
        }
    }

    public void AddHerb(string herbName, int amount)
    {
        if (!herbInventory.ContainsKey(herbName))
        {
            herbInventory[herbName] = 0;
        }

        herbInventory[herbName] += amount;
    }

    public void AddPotion(Potion potion)
    {
        potionInventory.Add(potion);
    }

    public List<Potion> GetPotions()
    {
        return new List<Potion>(potionInventory);
    }

    public int GetHerbCount(string herbName)
    {
        return herbInventory.ContainsKey(herbName) ? herbInventory[herbName] : 0;
    }

    public List<Plant> GetAllPlants()
    {
        return plantTypes;
    }
}
