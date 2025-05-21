using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HumanVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text symptomDisplayText;
    [SerializeField] private int minSymptomsToShow = 2;
    [SerializeField] private int maxSymptomsToShow = 3;

    public void DisplaySymptoms(Human human)
    {
        List<string> allSymptoms = new List<string>(human.GetSymptoms());
        int count = Mathf.Min(Random.Range(minSymptomsToShow, maxSymptomsToShow + 1), allSymptoms.Count);

        List<string> shownSymptoms = new List<string>();
        while (shownSymptoms.Count < count && allSymptoms.Count > 0)
        {
            int index = Random.Range(0, allSymptoms.Count);
            shownSymptoms.Add(allSymptoms[index]);
            allSymptoms.RemoveAt(index);
        }

        symptomDisplayText.text = $"Symptoms:\n- {string.Join("\n- ", shownSymptoms)}";
    }
}
