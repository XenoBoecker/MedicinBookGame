using System.Collections.Generic;
using UnityEngine;

public class PlantProduction : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private TimeManager timeManager;

    private int lastProcessedDay = -1;

    private void Update()
    {
        int currentDay = timeManager.CurrentDay;

        if (currentDay % 7 == 0 && currentDay != lastProcessedDay)
        {
            ProcessWeeklyProduction();
            lastProcessedDay = currentDay;
        }
    }

    private void ProcessWeeklyProduction()
    {
        List<Plant> plants = inventoryManager.GetAllPlants();

        foreach (var plant in plants)
        {
            inventoryManager.AddHerb(plant.HerbProduced, plant.AmountPerWeek);
            Debug.Log($"Produced {plant.AmountPerWeek}x {plant.HerbProduced} from {plant.Name}");
        }
    }
}
