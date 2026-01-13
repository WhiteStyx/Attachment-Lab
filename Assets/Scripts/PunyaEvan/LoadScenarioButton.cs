using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadScenarioButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI saveText;
    [SerializeField] private TextMeshProUGUI partnerNameText;
    [SerializeField] private TextMeshProUGUI dateText;

    private ScenarioData scenarioData;

    public void SetLoadScenarioButton(int index, ScenarioData scenarioData, LoadScenario loadScenario)
    {
        saveText.text = "Save Data "+index.ToString();

        partnerNameText.text = scenarioData.scenario;

        this.scenarioData = scenarioData;

        GetComponent<Button>().onClick.AddListener(() =>
        {
            loadScenario.ChangeSelectedScenarioData(this.scenarioData);
        });
    }
}
