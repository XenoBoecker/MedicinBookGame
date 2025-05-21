using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    [SerializeField] private GameObject bookPanel;
    [SerializeField] private TMP_Text pageTitle;
    [SerializeField] private TMP_Text pageContent;
    [SerializeField] private TextAsset diseasesJson;

    private enum PageType { Disease, Herb }
    private PageType currentPageType = PageType.Disease;

    private List<Disease> diseases = new List<Disease>();
    private List<HerbInfo> herbs = new List<HerbInfo>();

    private int currentPage = 0;

    private void Awake()
    {
        // Load diseases from JSON
        DiseaseListWrapper dWrap = JsonUtility.FromJson<DiseaseListWrapper>(diseasesJson.text);
        diseases = dWrap.diseases;

        BuildHerbInfoFromDiseases();

        UpdatePage();
    }

    public void ToggleBook()
    {
        bookPanel.SetActive(!bookPanel.activeSelf);
    }

    public void NextPage()
    {
        int max = (currentPageType == PageType.Disease) ? diseases.Count : herbs.Count;
        if (currentPage < max - 1)
        {
            currentPage++;
            UpdatePage();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
        }
    }

    public void SwitchPageType()
    {
        currentPageType = currentPageType == PageType.Disease ? PageType.Herb : PageType.Disease;
        currentPage = 0;
        UpdatePage();
    }

    private void UpdatePage()
    {
        if (currentPageType == PageType.Disease)
        {
            var d = diseases[currentPage];
            pageTitle.text = $"Disease: {d.name}";
            pageContent.text = $"Symptoms:\n- {string.Join("\n- ", d.symptoms)}\n\nCured by:\n- {string.Join("\n- ", d.cures)}";
        }
        else
        {
            var h = herbs[currentPage];
            pageTitle.text = $"Herb: {h.Name}";
            pageContent.text = $"Helps with:\n- {string.Join("\n- ", h.HelpsWithDiseases)}";
        }
    }

    private void BuildHerbInfoFromDiseases()
    {
        var herbDict = new Dictionary<string, List<string>>();

        foreach (var disease in diseases)
        {
            foreach (var herb in disease.cures)
            {
                if (!herbDict.ContainsKey(herb))
                    herbDict[herb] = new List<string>();

                herbDict[herb].Add(disease.name);
            }
        }

        herbs = new List<HerbInfo>();

        foreach (var kvp in herbDict)
        {
            herbs.Add(new HerbInfo
            {
                Name = kvp.Key,
                HelpsWithDiseases = kvp.Value
            });
        }

        // Sort herbs alphabetically for nicer browsing
        herbs = herbs.OrderBy(h => h.Name).ToList();
    }

    [System.Serializable]
    private class DiseaseListWrapper
    {
        public List<Disease> diseases;
    }

    private class HerbInfo
    {
        public string Name;
        public List<string> HelpsWithDiseases;
    }
}
