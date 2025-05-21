using UnityEngine;

public class ApplyPotion : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private HumanSpawner humanSpawner;

    public void TryApplyPotionToHuman(Human human, Potion potion)
    {
        if (human.IsCured)
        {
            Debug.Log("This human is already cured.");
            return;
        }

        bool success = false;

        foreach (string herb in potion.Ingredients)
        {
            if (human.AssignedDisease.cures.Contains(herb))
            {
                success = true;
                break;
            }
        }

        if (success)
        {
            human.IsCured = true;
            Destroy(human.gameObject);
            Debug.Log("Potion was successful! Human cured.");
            humanSpawner.SpawnNewHuman();
        }
        else
        {
            Debug.Log("Potion was not helpful.");
        }
    }
}
