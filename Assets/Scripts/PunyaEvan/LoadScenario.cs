using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LoadScenario : MonoBehaviour
{
    [SerializeField] private Button confirmLoadButton;
    [Header("SAVE DATA REF")]
    [SerializeField] private Transform loadButtonContainerTransform;
    [SerializeField] private Transform loadButtonPrefab;

    private List<LoadProfileButton> loadProfileButtonList = new List<LoadProfileButton>();

    private ScenarioData selectedScenarioData = new ScenarioData();

    private void Awake()
    {
        RemoveLoadButton();
    }

    private void Start()
    {
        confirmLoadButton.onClick.AddListener(() => 
        {
            if (selectedScenarioData != null)
                ScenarioSetUpMenu.instance.ChangeScenarioData(selectedScenarioData);

            Hide();
        });
    }

    public void ChangeSelectedScenarioData(ScenarioData scenarioData)
    {
        selectedScenarioData = scenarioData;
    }

    public void RemoveLoadButton()
    {
        foreach(Transform t in loadButtonContainerTransform)
        {
            Destroy(t.gameObject);
        }

        loadProfileButtonList.Clear();
    }

    public void CreateLoadButton()
    {
        RemoveLoadButton();

        var allScenaios = SaveManager.LoadJSONWithTime<ScenarioData>("ScenarioData");

        int index = 1;
        foreach (var (data, time) in allScenaios)
        {
            Transform loadButtonTransform = Instantiate(loadButtonPrefab, loadButtonContainerTransform);

            LoadScenarioButton loadScenarioButton = loadButtonTransform.GetComponent<LoadScenarioButton>();

            loadScenarioButton.SetLoadScenarioButton(index, data, time, this);
            index++;
        };
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
