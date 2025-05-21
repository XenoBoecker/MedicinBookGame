using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewPlant", menuName = "ScriptableObjects/Plant")]
public class Plant : ScriptableObject
{
    public string Name;
    public string HerbProduced;
    public int AmountPerWeek;
    public int CurrentStock;
}
