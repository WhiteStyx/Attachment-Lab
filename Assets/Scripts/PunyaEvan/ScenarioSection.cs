using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ScenarioSection : MonoBehaviour
{
    [SerializeField] private TMP_InputField scenarioInputField;

    private void Start()
    {
        scenarioInputField.onValueChanged.AddListener(ScenarioSetUpMenu.instance.ChangeScenario);

        ScenarioSetUpMenu.instance.OnScenarioDataChanged += ScenarioSetUpMenu_OnScenarioDataChanged;
    }

    private void ScenarioSetUpMenu_OnScenarioDataChanged(object sender, ScenarioData e)
    {
        scenarioInputField.text = e.scenario;
    }
}
