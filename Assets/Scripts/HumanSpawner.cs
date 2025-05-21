using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HumanSpawner : MonoBehaviour
{
    [SerializeField] private TextAsset diseasesJson;
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private Transform spawnPoint;

    private List<Disease> allDiseases;

    private void Awake()
    {
        LoadDiseasesFromJson();
    }

    private void Start()
    {
        SpawnNewHuman();
    }

    private void LoadDiseasesFromJson()
    {
        if (diseasesJson != null)
        {
            DiseaseListWrapper wrapper = JsonUtility.FromJson<DiseaseListWrapper>(diseasesJson.text);
            allDiseases = wrapper.diseases;

            Debug.Log("Loaded Diseases:");
            for (int i = 0; i < allDiseases.Count; i++)
            {
                Debug.Log(allDiseases[i].name);
            }
        }
        else
        {
            Debug.LogError("Diseases JSON not assigned!");
            allDiseases = new List<Disease>();
        }
    }

    public void SpawnNewHuman()
    {
        if (allDiseases == null || allDiseases.Count == 0) return;

        GameObject newHuman = Instantiate(humanPrefab, spawnPoint.position, Quaternion.identity);
        Human humanComponent = newHuman.GetComponent<Human>();

        Disease randomDisease = allDiseases[Random.Range(0, allDiseases.Count)];
        humanComponent.AssignDisease(randomDisease);
    }

    [System.Serializable]
    private class DiseaseListWrapper
    {
        public List<Disease> diseases;
    }
}
