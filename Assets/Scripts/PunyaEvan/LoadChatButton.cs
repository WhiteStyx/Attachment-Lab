using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadChatButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI saveText;
    [SerializeField] private TextMeshProUGUI scenarioNameText;
    [SerializeField] private TextMeshProUGUI dateText;

    private ChatData chatData;
    
    public void SetLoadChatButton(int index, ChatData chatData, DateTime time, LoadChat loadChat)
    {
        saveText.text = "Save Data"+index.ToString();
        scenarioNameText.text = chatData.scenario + " - " + chatData.partnerName;
        dateText.text = time.ToString("dd MMM yyyy");

        this.chatData = chatData;

        GetComponent<Button>().onClick.AddListener(() =>
        {
            loadChat.LoadChatSession(this.chatData);
        });
    }
}
