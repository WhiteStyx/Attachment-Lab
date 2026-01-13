using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.IO;
using System.Data;

public class ScenarioSetUpMenu : MonoBehaviour
{
    public static ScenarioSetUpMenu instance;

    public event EventHandler<ScenarioData> OnScenarioDataChanged;

    [SerializeField] private Button startButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private TextMeshProUGUI partnerText;
    [SerializeField] private string language;

    private ScenarioData createdScenarioData = new();

    private void Awake()
    {
        instance = this;

        Hide();
    }

    private void Start()
    {
        backButton.onClick.AddListener(()=> {
            MainMenu_Evan.instance.Show();
            Hide();
        });

        saveButton.onClick.AddListener(()=> {
            string rawName = createdScenarioData.scenario;
            string safeName = string.Join("_", rawName.Split(Path.GetInvalidFileNameChars()));
            SaveManager.SaveToJSON(createdScenarioData, safeName, "ScenarioData");
        });

        startButton.onClick.AddListener(() =>
        {
            StartNewChatSession();
            SimulationMenu.instance.Show();
            Hide();
        });
    }

    public void ChangeScenarioData(ScenarioData scenarioData)
    {
        createdScenarioData = scenarioData;
        partnerText.text = scenarioData.partnerName;


        OnScenarioDataChanged?.Invoke(this, createdScenarioData);
    }

    public void ChangeScenario(string scenario)
    {
        createdScenarioData.scenario = scenario;
    }

    public void ChangePartner(string partnerName, string profileID)
    {
        partnerText.text = partnerName;
        createdScenarioData.partnerName = partnerName;
        createdScenarioData.partnerProfileID = profileID;
    }

    public void ChangePartnerDifficulty(float difficulty)
    {
        createdScenarioData.partnerDifficulty = difficulty;
    }

    public void ChangeFoulLanguage(bool foulLanguage)
    {
        createdScenarioData.foulLanguage = foulLanguage;
    }

    public void ChangePlayerEmotions(bool playerEmotion)
    {
        createdScenarioData.playerEmotions = playerEmotion;
    }

    public void ChangePartnerFeelings(bool feelings)
    {
        createdScenarioData.partnerFeelings = feelings;
    } 

    // public void ChangeTherapeuticAdvice(string advice)
    // {
    //     createdScenarioData.therapeuticAdvice = advice;
    // }

    public void StartNewChatSession()
    {
        string currentChatID = System.Guid.NewGuid().ToString();

        ChatData session = new()
        {
            chatId = currentChatID,
            partnerProfileID = createdScenarioData.partnerProfileID,
            scenario = createdScenarioData.scenario
        };
        SaveManager.SaveToJSON(session, currentChatID, "ChatData");

        ProfileData partnerProfile = SaveManager.LoadSingleJSON<ProfileData>(createdScenarioData.partnerProfileID, "ProfileData");

        if (partnerProfile == null)
        {
            Debug.LogError("Partner Profile Not Found!");
            return;
        }

        string identity =   $"Name: {partnerProfile.firstName} {partnerProfile.lastName}. " +
                            $"Gender: {partnerProfile.gender}. " +
                            $"Personality: {partnerProfile.myersBriggs}. " +
                            $"Energy Level: {partnerProfile.energy}/10. " +
                            $"Traits: Intelligence {partnerProfile.intelligence}/10, Agreeableness {partnerProfile.agreeableness}/10. " +
                            $"Background: {partnerProfile.background}." +
                            $"Language: {language}.";

        string  rules = $"Current Scenario: {createdScenarioData.scenario}. ";
                rules += $"Challenge Level: {createdScenarioData.partnerDifficulty}/10. ";
                rules += "Higher difficulty means you are harder to persuade, more cynical, and more defensive. ";
                rules += createdScenarioData.foulLanguage ? "You may use harsh language. " : "Strictly no swearing. ";
                rules += createdScenarioData.partnerFeelings ? "Show deep emotional vulnerability and express your inner feelings. " : "Be more stoic, reserved, and hide your emotions. ";
                rules += createdScenarioData.playerEmotions ? "Use asterisks (e.g., *smiles*) to describe your physical actions and emotions. " : "Do not use asterisks or any narration. Send ONLY the dialog text without describing your actions.";

        SimulationMenu.instance.InitializeChat(currentChatID, partnerProfile.firstName, identity, rules);
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
