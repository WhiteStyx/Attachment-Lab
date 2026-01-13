using UnityEngine;
using UnityEngine.UI;

public class GameOptionSection : MonoBehaviour
{
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Toggle foulLanguage;
    [SerializeField] private Toggle playerEmotion;
    [SerializeField] private Toggle feelings;

    private void Start()
    {
        difficultySlider.onValueChanged.AddListener(ScenarioSetUpMenu.instance.ChangePartnerDifficulty);
        
        foulLanguage.onValueChanged.AddListener(ScenarioSetUpMenu.instance.ChangeFoulLanguage);
        playerEmotion.onValueChanged.AddListener(ScenarioSetUpMenu.instance.ChangePlayerEmotions);
        feelings.onValueChanged.AddListener(ScenarioSetUpMenu.instance.ChangePartnerFeelings);

        ScenarioSetUpMenu.instance.OnScenarioDataChanged += ScenarioSetUpMenu_OnScenarioDataChanged;
    }

    private void ScenarioSetUpMenu_OnScenarioDataChanged(object sender, ScenarioData e)
    {
        difficultySlider.value = e.partnerDifficulty;
        foulLanguage.isOn = e.foulLanguage;
        playerEmotion.isOn = e.playerEmotions;
        feelings.isOn = e.partnerFeelings;
    }
}
