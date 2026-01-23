using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LoadScenarioButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI saveText;
    [SerializeField] private TextMeshProUGUI partnerNameText;
    [SerializeField] private TextMeshProUGUI dateText;

    private ScenarioData scenarioData;

    public void SetLoadScenarioButton(int index, ScenarioData scenarioData, DateTime time, LoadScenario loadScenario)
    {
        saveText.text = "Save Data "+index.ToString();
        partnerNameText.text = scenarioData.scenario;
        dateText.text = time.ToString("dd MMM yyyy");

        this.scenarioData = scenarioData;

        GetComponent<Button>().onClick.AddListener(() =>
        {
            loadScenario.ChangeSelectedScenarioData(this.scenarioData);
        });
    }
}
