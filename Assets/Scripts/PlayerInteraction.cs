using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Mortar mortar;
    [SerializeField] private BookUI bookUI;
    [SerializeField] private HumanVisualizer humanVisualizer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject clicked = hit.collider.gameObject;

            if (clicked.CompareTag("Ingredient"))
            {
                Ingredient ingredient = clicked.GetComponent<Ingredient>();
                mortar.SelectIngredient(ingredient);
            }
            else if (clicked.CompareTag("Mortar"))
            {
                mortar.CraftPotion();
            }
            else if (clicked.CompareTag("Human"))
            {
                Human human = clicked.GetComponent<Human>();
                if (human != null) 
                {
                    humanVisualizer.DisplaySymptoms(human);
                    // human.DrinkPotion()
                }
            }

            Debug.Log("Clicked on " + hit.collider.name + " Tag: " + hit.collider.tag);
        }
    }
}
