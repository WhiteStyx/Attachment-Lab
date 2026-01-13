// using UnityEngine;
// using UnityEngine.UI;
// using System;
// using TMPro;
// using System.IO;

// public class CreateChatData : MonoBehaviour
// {
//     public static ScenarioSetUpMenu instance;

//     public event EventHandler<ChatData> OnChatDataChanged;

//     private ScenarioData createdScenarioData = new();

//     private void Awake()
//     {
//         instance = this;

//         Hide();
//     }

//     private void Start()
//     {
//         backButton.onClick.AddListener(()=> {
//             MainMenu_Evan.instance.Show();
//             Hide();
//         });

//         saveButton.onClick.AddListener(()=> {
//             string rawName = createdScenarioData.scenario;
//             string safeName = string.Join("_", rawName.Split(Path.GetInvalidFileNameChars()));
//             SaveManager.SaveToJSON(createdScenarioData, safeName, "ScenarioData");
//         });

//         startButton.onClick.AddListener(() =>
//         {
//             SimulationMenu.instance.Show();
//             Hide();
//         });
//     }

//     public void ChangeScenarioData(ScenarioData scenarioData)
//     {
//         createdScenarioData = scenarioData;
//         partnerText.text = scenarioData.partnerName;


//         OnScenarioDataChanged?.Invoke(this, createdScenarioData);
//     }

//     public void ChangeScenario(string scenario)
//     {
//         createdScenarioData.scenario = scenario;
//     }

//     public void ChangePartner(string partnerName, string profileID)
//     {
//         partnerText.text = partnerName;
//         createdScenarioData.partnerName = partnerName;
//         createdScenarioData.partnerProfileID = profileID;
//     }

//     public void ChangePartnerDifficulty(float difficulty)
//     {
//         createdScenarioData.partnerDifficulty = difficulty;
//     }

//     public void ChangeFoulLanguage(bool foulLanguage)
//     {
//         createdScenarioData.foulLanguage = foulLanguage;
//     }

//     public void ChangePlayerEmotions(bool playerEmotion)
//     {
//         createdScenarioData.playerEmotions = playerEmotion;
//     }

//     public void ChangePartnerFeelings(bool feelings)
//     {
//         createdScenarioData.partnerFeelings = feelings;
//     } 

//     // public void ChangeTherapeuticAdvice(string advice)
//     // {
//     //     createdScenarioData.therapeuticAdvice = advice;
//     // }

//     public void Show()
//     {
//         gameObject.SetActive(true);
//     }

//     public void Hide()
//     {
//         gameObject.SetActive(false);
//     }
// }
