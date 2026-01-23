using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadChat : MonoBehaviour
{
    [SerializeField] private Button confirmLoadChat;
    [Header("SAVE DATA REF")]
    [SerializeField] private Transform loadButtonContainerTransform;
    [SerializeField] private Transform loadButtonPrefab;

    private List<LoadChatButton> loadChatButtonList = new();
    
    private ChatData selectedChatData = new();

    private void Awake()
    {
        RemoveLoadButton();
    }

    void Start()
    {
        confirmLoadChat.onClick.AddListener(() =>
        {
            SimulationMenu.instance.Show();
            if (selectedChatData != null)
                SimulationMenu.instance.InitializeChat(
                    selectedChatData.chatId, 
                    selectedChatData.partnerProfileID,
                    selectedChatData.aiIdentity, 
                    selectedChatData.aiRules);
            Hide();
        });
    }

    public void LoadChatSession(ChatData chatData)
    {
        selectedChatData = chatData;
    }

    public void RemoveLoadButton()
    {
        foreach(Transform t in loadButtonContainerTransform)
        {
            Destroy(t.gameObject);
        }

        loadChatButtonList.Clear();
    }

    public void CreateLoadButton()
    {
        RemoveLoadButton();

        var allChats = SaveManager.LoadJSONWithTime<ChatData>("ChatData");

        int index = 1;
        foreach (var (data, time) in allChats)
        {
            Transform loadButtonTransform = Instantiate(loadButtonPrefab, loadButtonContainerTransform);

            LoadChatButton loadChatButton = loadButtonTransform.GetComponent<LoadChatButton>();

            loadChatButton.SetLoadChatButton(index, data, time, this);
            index++;
        }
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
